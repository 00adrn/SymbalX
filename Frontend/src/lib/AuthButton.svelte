<script lang="ts">
    import {spotifyBE} from '../lib/apiRequests';
    import {onMount} from 'svelte';

    let loggedIn = $state(false);
    let isLoading = $state(true);

    async function login() {
        spotifyBE.startAuthentication();
    }

    async function checkLoginStatus() {
        loggedIn = await spotifyBE.verifyLogin();
    }

    onMount(async () => {
        await checkLoginStatus();
        isLoading = false;
    });

</script>

{#if isLoading}
    <p>loading...</p>
{:else if !loggedIn}
    <button onclick = { login }>
        Login
    </button>
{:else}
<p>Logged in</p>
{/if}



