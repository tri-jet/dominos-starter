using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string _connectionString;

        public AuthController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Note: In real enterprise apps, use Parameters to avoid SQL Injection!
                string sql = "SELECT COUNT(1) FROM Users WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", request.Username);
                cmd.Parameters.AddWithValue("@password", request.Password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    return Ok(new {
                        message = "Login successful!",
                        user = request.Username,
                        token = System.Guid.NewGuid().ToString()    //Create a basic token for protected routes
                    });
                }
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginRequest request)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string checkSql = "SELECT COUNT(1) FROM Users WHERE Username = @username";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@username", request.Username);

                conn.Open();
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    return BadRequest(new { message = "User already exists" });
                }

                string insertSql = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@username", request.Username);
                insertCmd.Parameters.AddWithValue("@password", request.Password);

                insertCmd.ExecuteNonQuery();

                return Ok(new { message = "User registered successfully" });
            }
        }
    }

    // This is the "DTO" (Data Transfer Object) for the login request
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}