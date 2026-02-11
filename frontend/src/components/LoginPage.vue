<template>
  <h2>Login</h2>

  <input v-model="username" placeholder="Username" />
  <input v-model="password" type="password" placeholder="Password" />

  <button @click="login">Login</button>

  <p v-if="error" style="color:red">{{ error }}</p>

  <p>
    <router-link to="/register">Register</router-link> |
    <router-link to="/forgot-password">Forgot Password?</router-link> | 
    <router-link to="/landing">Back to Landing Page</router-link>
  </p>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const username = ref('')
const password = ref('')
const error = ref('')

const login = async () => {
  error.value = ''

  const res = await fetch('http://localhost:5000/api/auth/login', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({
      username: username.value,
      password: password.value
    })
  })

  if (res.ok) {
    // fake token for demo purposes
    localStorage.setItem('token', 'logged-in')
    router.push('/dashboard')
  } else {
    error.value = 'Invalid credentials'
  }
}
</script>