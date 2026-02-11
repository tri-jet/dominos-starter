import { createRouter, createWebHistory} from 'vue-router'

import LoginPage from '../components/LoginPage.vue'
import ForgotPassword from '../components/ForgotPassword.vue'
import LandingPage from '../components/LandingPage.vue'
import RegisterPage from '../components/RegisterPage.vue'
import Dashboard from '../components/Dashboard.vue'

const routes = [
    { path: '/', redirect: '/login' },

  { path: '/login', component: LoginPage },
  { path: '/register', component: RegisterPage },
  { path: '/forgot-password', component: ForgotPassword },
  { path: '/landing', component: LandingPage},
  { path: '/dashboard', component: Dashboard},
]

const router = createRouter({
    history: createWebHistory(),
    routes
});

//Go back to landing page if don't have auth token
router.beforeEach((to) => {
    if(to.meta.requiresAuth){
        const token = localStorage.getItem('token')
        if(!token) return 'landing'
    }
});

export default router;