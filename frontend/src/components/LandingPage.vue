<template>
  <div class="flex flex-col items-center justify-center min-h-[60vh] text-center px-4">
    <h1 class="text-5xl font-black text-[#006491] mb-6 uppercase tracking-tighter">
      Domino's
    </h1>

    <p class="max-w-md text-gray-600 text-lg mb-8 leading-relaxed">
      Domino's Stock Management software to aid in managing 
      Domino's delivery outlets' stock.
    </p>
    <p class="max-w-md text-gray-600 text-lg mb-8 leading-relaxed">
      Here you will be able to login with your staff details and view 
      the information for your outlet.
    </p>

    <button 
      @click="startLogin"
      class="bg-[#E31837] text-white font-bold py-3 px-8 rounded-full hover:bg-[#c4152f] transition-all transform hover:scale-105 shadow-lg"
    >
      Staff Login
    </button>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

const startLogin = () => {
  router.push('/login')
}

</script>