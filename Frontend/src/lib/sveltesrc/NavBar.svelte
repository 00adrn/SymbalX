<script lang="ts">
    import ProfileCard from './ProfileCard.svelte'
    import AuthButton from './AuthButton.svelte'
    import {onMount} from 'svelte';
    import {authenticator} from '../sveltejssrc/logInInfo.svelte.js'
    import type {Profile} from "../tssrc/types"
    import { spotifyBE } from "../tssrc/apiRequests";

    onMount(async () => {
        authenticator.refreshLoginStatus();
    });

    async function fetchTrackInfo(): Promise<Profile|null> {
        if (!authenticator.checkLoginStatus())
            return null;
        return await spotifyBE.fetchProfileInfo()
    }

</script>

<div class = "navbar">
    <p class="navbar-title">symbalx</p>
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
        height: 52px;
        background-color: #3d754c;
        border-radius: 0, 0, 8px, 8px;
    }
    .navbar-title {
        font-size: 20px;
        font-family: sans-serif;
        padding-left: 12px;
        padding-right: 8px;
        font-weight: bold;
        color: white;
        letter-spacing: 8px
    }
    .navbar-profile {
        display: flex;
        flex-direction: row;
        position: fixed;
        right: 0;
    }
</style>