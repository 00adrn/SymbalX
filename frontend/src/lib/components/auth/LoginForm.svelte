<script lang="ts">
    import { auth } from "$lib/supabaseClient"
    import { goto } from "$app/navigation";

    let email: string = $state("");
    let password: string = $state("");

    let attemptFeedback: string = $state("");
    let attempted: boolean = $state(false);


    let onSumbit = async () => {
        attempted = true;

        if (email === "" || password === "") {
            attemptFeedback = "Please properly fill out all fields";
            return;
        }

        const res = await auth.singIn(email, password);

        if (res) {
            attemptFeedback = "Success. Please check your email to verify your account.";
            return;
        }

        attemptFeedback = "Something went wrong. Please try again.";
    }
</script>

<form class="login-register-form" onsubmit={onSumbit}>
    <div class="input-container">
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
        height: 100%;
        width: 100%;
        margin: .4rem;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
</style>