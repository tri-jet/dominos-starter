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
  <main class="min-h-screen bg-gray-50 font-sans">
    <nav class="p-6 flex justify-center">
      <div class="flex gap-2">
        <div class="w-8 h-8 bg-[#E31837] rotate-45 flex items-center justify-center">
          <div class="w-2 h-2 bg-white rounded-full"></div>
        </div>
        <div class="w-8 h-8 bg-[#006491] rotate-45 flex items-center justify-center gap-1">
          <div class="w-2 h-2 bg-white rounded-full"></div>
          <div class="w-2 h-2 bg-white rounded-full"></div>
        </div>
      </div>
    </nav>

    <Transition name="fade" mode="out-in">
      <div v-if="view === 'landing'">
        <LandingPage @start-login="goToLogin" />
      </div>
      <div v-else>
        <LoginPage @go-back="view = 'landing'" />
      </div>
    </Transition>
  </main>
</template>

<style>
/* Smooth transition between pages */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.3s ease;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>