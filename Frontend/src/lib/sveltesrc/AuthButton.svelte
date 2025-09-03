<script lang="ts">
    import {onMount} from 'svelte';
    import {authenticator} from '../sveltejssrc/logInInfo.svelte.js'
    let isLoading = $state(true);

    async function login() {
        authenticator.startAuthentication();
    }

    onMount(async () => {
        authenticator.refreshLoginStatus();
        isLoading = false;
    });

</script>

{#if isLoading}
    <p>Loading...</p>
{:else if !authenticator.checkLoginStatus()}
    <button onclick = { login }>
        Login
    </button>
{:else}
<p>Logged in</p>
{/if}



