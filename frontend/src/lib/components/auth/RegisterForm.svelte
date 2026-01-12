<script lang="ts">
    import { auth } from "$lib/supabaseClient"

    let { data } = $props();

    let username: string = $state("");
    let email: string = $state("");
    let password: string = $state("");

    let attemptFeedback: string = $state("");
    let attempted: boolean = $state(false);


    let onSumbit = async () => {
        attempted = true;

        if (username === "" || email === "" || password === "") {
            attemptFeedback = "Please properly fill out all fields";
            return;
        }

        const res = await auth.signUp(username, email, password);

        if (res) {
            attemptFeedback = "Success. Please check your email to verify your account.";
            return;
        }

        attemptFeedback = "Something went wrong. Please try again.";
    }
</script>

<form class="login-register-form" onsubmit={onSumbit} style="--color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <div class="input-container">
        <input type="text" placeholder="Enter username..." bind:value={username} class="">
        <input type="email" placeholder="Enter email..." bind:value={email}>
        <input type="password" placeholder="Enter a password..." bind:value={password}>
        <button type="submit">Submit</button>
        {#if attempted}
            <p>{attemptFeedback}</p>
        {/if}
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
        padding: .4rem;
        height: 100%;
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 1rem;
    }
    .input-container input {
        width: 100%;
        background: var(--color-2);
        color: white;
        font-size: 1.8rem;
        padding: .4rem;
        border-radius: .4rem;
        border: 1px gray solid
    }

    .input-container input:hover {
        background: var(--color-0);
    }
    .input-container button {
        width: 75%;
        height: 4rem;
        background: var(--color-1);
        color: white;
        font-size: 1.8rem;
        padding: .4rem;
        border: 1px gray solid;
        border-radius: .4rem;
    }

    .input-container button:hover {
        background: var(--color-0);
    }

</style>