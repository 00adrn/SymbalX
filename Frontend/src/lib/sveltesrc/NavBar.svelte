<script lang="ts">
    import ProfileCard from './ProfileCard.svelte'
    import AuthButton from './AuthButton.svelte'
    import {onMount} from 'svelte';
    import {authenticator} from '../sveltejssrc/logInInfo.svelte.js'
    import type {Profile} from "../tssrc/types"
    import { spotifyApi } from "../tssrc/apiRequests";

    onMount(async () => {
        authenticator.refreshLoginStatus();
    });

    async function fetchTrackInfo(): Promise<Profile|null> {
        if (!authenticator.checkLoginStatus())
            return null;
        return await spotifyApi.fetchProfileInfo()
    }

</script>

<div class = "navbar">
        <p class="navbar-title"><a href="localhost:5173/" >symbalx</a></p>
    <div class="navbar-profile">
        {#if !authenticator.checkLoginStatus()}
            <AuthButton />
        {:else}
            {#await fetchTrackInfo()}
            <p>Loading...</p>
            {:then profile}
            <ProfileCard profileInfo={profile} />
            {/await}
        {/if}
    </div>
</div>

<style >
    .navbar {
        display: flex;
        align-items: center;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 4em;
        background-color: #3d754c;
        border-radius: 0, 0, 8px, 8px;
        gap: 0.5em;
    }
    .navbar-title {
        font-size: 2em;
        font-family: sans-serif;
        font-weight: bold;
        color: white;
        letter-spacing: 8px;
        margin: 0 0.5em 0 0.5em;
    }
    .navbar-title a {
        color: white;
        text-decoration: none;
        text-decoration-color: white;
        font-family: "Helvetica Neue", sans-serif;
        font-weight: bold;
    }
    .navbar-profile {
        display: flex;
        flex-direction: row;
        position: fixed;
        right: 0;
    }

</style>