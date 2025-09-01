import { defineConfig } from 'vite'
import { svelte } from '@sveltejs/vite-plugin-svelte'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [svelte()],
  server: {
    // This is the port your Vite dev server will run on.
    port: 5173,

    proxy: {
      '/api': {
        target: 'http://[::1]:5157',
        
        changeOrigin: true,
        secure: false, // Use this if your backend has a self-signed SSL certificate.
      }
    }
  }
})