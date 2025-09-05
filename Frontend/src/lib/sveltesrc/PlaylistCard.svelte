<script lang="ts">
import { spotifyApi } from '../tssrc/apiRequests'
import { authenticator } from '../sveltejssrc/logInInfo.svelte.js';

import TrackCard from './TrackCard.svelte';


</script>
<div class="playlist-card">
    {#if authenticator.checkLoginStatus()}
        {#await spotifyApi.fetchPlaylistInfo()}
            <p>waiting for response</p>
        {:then playlist}
            {#if playlist != null}
                {#each playlist.tracks as track}
                    <TrackCard trackInfo={track} />
                {/each}
            {/if}
        {/await}
    {/if}
</div>

<style>
    .playlist-card {
        display: flex;
        flex-direction: column;
        gap: 0.5em;
        margin: 0 0.5em 0 0.5em;
        width: fit-content;
    }
</style>