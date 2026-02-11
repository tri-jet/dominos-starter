<script setup>
import { useRouter } from 'vue-router'

const router = useRouter()

const logout = () => {
  localStorage.removeItem('token')
  router.push('/login')
}
</script>

<template>
  <h2>Dashboard</h2>
  <p>You are logged in.</p>

  <button @click="logout">Logout</button>
</template>
