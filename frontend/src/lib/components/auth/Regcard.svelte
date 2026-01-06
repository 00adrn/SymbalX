<script lang="ts">
    import { auth } from "$lib/supabaseClient"

    let username: string = $state("");
    let email: string = $state("");
    let password: string = $state("");
    
    let onSubmit = async () => {
        if (username == "" || email == "" || password == "")
            return;

        const resp = await auth.register(email, username, password)
        
        if (resp.error) {
            console.log("error")
        }
        else {
            console.log("success")
        }
    }
</script>

<form class="register-form" onsubmit={onSubmit}>
    <input type="text" placeholder="Enter username" bind:value={username}/>
    <input type="email" placeholder="Enter email" bind:value={email}/>
    <input type="password" placeholder="Enter password" bind:value={password}/>
    <button type="submit">Register</button>
</form>

<style>
    .register-form {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
</style>