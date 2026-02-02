<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-96 border-t-4 border-blue-600">
      <h2 class="text-2xl font-bold mb-6 text-red-600 text-center">Dominos Starter Login</h2>
      
      <form @submit.prevent="handleLogin" class="space-y-4">
        <div>
          <label class="block text-sm font-medium text-gray-700">Username</label>
          <input 
            v-model="form.username" 
            type="text" 
            class="mt-1 block w-full border border-gray-300 rounded-md p-2 shadow-sm focus:ring-blue-500 focus:border-blue-500" 
            placeholder="admin"
            required
          />
        </div>

        <div>
          <label class="block text-sm font-medium text-gray-700">Password</label>
          <input 
            v-model="form.password" 
            type="password" 
            class="mt-1 block w-full border border-gray-300 rounded-md p-2 shadow-sm focus:ring-blue-500 focus:border-blue-500" 
            placeholder="••••••••"
            required
          />
        </div>

        <button 
          type="submit" 
          :disabled="loading"
          class="w-full bg-blue-600 text-white py-2 px-4 rounded-md hover:bg-blue-700 transition duration-200 disabled:bg-gray-400"
        >
          {{ loading ? 'Signing in...' : 'Login' }}
        </button>
      </form>

      <p v-if="message" :class="['mt-4 text-center text-sm', isError ? 'text-red-600' : 'text-green-600']">
        {{ message }}
      </p>
      <button 
      @click="emit('go-back')"
      class="absolute top-4 left-4 text-gray-500 hover:text-[#006491] flex items-center gap-1 font-medium"
    >
      ← Return to Home
    </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue'

const emit = defineEmits(['go-back'])

// Define an interface for your form data
interface LoginForm {
  username: string;
  password: string;
}

const form = reactive<LoginForm>({
  username: '',
  password: ''
})

const message = ref<string>('')
const isError = ref<boolean>(false)
const loading = ref<boolean>(false)

const handleLogin = async (): Promise<void> => {
  loading.value = true
  message.value = ''
  
  try {
    const response = await fetch('http://localhost:5000/api/auth/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(form)
    })

    const data = await response.json()

    if (!response.ok) {
      throw new Error(data.message || 'Unauthorized')
    }

    message.value = `Success! Welcome ${data.user}`
    isError.value = false
    
  } catch (err: any) {
    isError.value = true
    message.value = err.message
  } finally {
    loading.value = false
  }
}
</script>