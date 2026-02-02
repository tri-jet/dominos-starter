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
                    return Ok(new { message = "Login successful!", user = request.Username });
                }
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }

    // This is the "DTO" (Data Transfer Object) for the login request
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}