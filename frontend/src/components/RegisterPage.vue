<template>
  <h2>Register</h2>

  <input v-model="username" placeholder="Username" />
  <input v-model="password" type="password" placeholder="Password" />

  <button @click="register">Register</button>

  <p>
    Already have an account?  
    <router-link to="/login">Login</router-link>
  </p>
  

  <p>{{ message }}</p>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const username = ref('')
const password = ref('')
const message = ref('')

const register = async () => {
  try {
    await fetch('http://localhost:5000/api/auth/register', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        username: username.value,
        password: password.value
      })
    })

    message.value = 'Registration successful. Please login.'
    setTimeout(() => router.push('/login'), 1000)
  } catch (err) {
    message.value = 'Registration failed'
  }
}
</script>
