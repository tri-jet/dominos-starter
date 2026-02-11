<script setup lang="ts">
import { ref } from 'vue'
import LandingPage from './components/LandingPage.vue'
import LoginPage from './components/LoginPage.vue'

// Logic to switch between 'landing' and 'login'
const view = ref<'landing' | 'login'>('landing')

const goToLogin = () => {
  view.value = 'login'
}
</script>

<template>
  <router-view/>
</template>
