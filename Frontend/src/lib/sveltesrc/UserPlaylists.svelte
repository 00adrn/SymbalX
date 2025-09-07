<script lang="ts">
    import {authenticator} from "../sveltejssrc/logInInfo.svelte.js"
    import {spotifyApi} from "../tssrc/apiRequests"

    import PlaylistThumbnail from "./PlaylistThumbnail.svelte"


</script>

{#if authenticator.checkLoginStatus()}
    {#await spotifyApi.fetchAllUserPlaylists()}
        <p>Loading...</p>
    {:then playlists}
    <div class="playlist-container"> 
        {#each playlists as playlist}
            <PlaylistThumbnail playlistInfo={playlist} />
        {/each}
        </div>
    {/await}
{:else}
    <p>Fetching...</p>
{/if}

<style>
    .playlist-container {
        display: flex;
        flex-wrap: wrap;
        flex-direction: row;
        justify-content: space-between;
    }
</style>