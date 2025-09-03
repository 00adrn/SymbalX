<script lang="ts">
    import {spotifyBE} from '../tssrc/apiRequests';
    import {onMount} from 'svelte';
    import {checkLoginStatus} from '../sveltejssrc/logInInfo.svelte.js'
    import {refreshLoginStatus} from '../sveltejssrc/logInInfo.svelte.js'

    let isLoading = $state(true);

    async function login() {
        spotifyBE.startAuthentication();
    }

    onMount(async () => {
        refreshLoginStatus();
        isLoading = false;
    });

</script>

{#if isLoading}
    <p>Loading...</p>
{:else if !checkLoginStatus()}
    <button onclick = { login }>
        Login
    </button>
{:else}
<p>Logged in</p>
{/if}



