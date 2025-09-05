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
        display: flex;
        justify-content: center;
        align-items: center;
        margin: 4px;
        height: 2em;
        width: 5em;
        font-size: 0.8em
    }
</style>



