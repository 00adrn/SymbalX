<script lang="ts">
    import { auth } from "$lib/supabaseClient"
    import { goto } from "$app/navigation";

    let username: string = $state("");
    let email: string = $state("");
    let password: string = $state("");
    let isLoggingIn: boolean = $state(true);
    let isFetching: boolean = $state(false);

    let onSumbit = async () => {
        if (username === "" || email === "" || password === "")
            return;
        isFetching = true;

        if (isLoggingIn) {
            const res = await auth.login(email, password);

            if (res.error) {
                return;
            }
            isFetching = false;
            console.log(res);
            goto("/");
            return;
        }

        const res = await auth.register(username, email, password);
        if (res.error) {
            return;
        }

        await auth.login(email, password);
        
        isFetching = false;
        goto("/");
        
    }
</script>

<form class="login-register-form" onsubmit={onSumbit}>
    <div class="input-container">
        <input type="text" placeholder="Enter username..." bind:value={username} class="">
        <input type="email" placeholder="Enter email..." bind:value={email}>
        <input type="password" placeholder="Enter a password..." bind:value={password}>
        <button type="submit">Submit</button>
    </div>
</form>

<style>
    .login-register-form {
        width: 100%;
        height: 100%;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    .input-container {
        height: 100%;
        width: 100%;
        margin: .4rem;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
</style>