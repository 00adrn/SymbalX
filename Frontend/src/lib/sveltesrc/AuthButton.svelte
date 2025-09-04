<script lang="ts">
    import {authenticator} from '../sveltejssrc/logInInfo.svelte.js'

    async function login() {
        authenticator.startAuthentication();
    }

</script>
    <button onclick = { login }>
        Login
    </button>
<style>
    button {
        margin: 4px;
    }
</style>



