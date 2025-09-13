<script lang="ts">
    import {authenticator} from "../sveltejssrc/logInInfo.svelte.js"
    import {spotifyApi} from "../tssrc/apiRequests"

    import PlaylistThumbnail from "./PlaylistThumbnail.svelte"

    let { filteredSearchTerm } = $props();
</script>

<p>{filteredSearchTerm}</p>

{#if authenticator.checkLoginStatus()}
    {#await spotifyApi.fetchAllUserPlaylists()}
        <p>Loading...</p>
    {:then playlists}
    <div class="playlist-container"> 
        {#each playlists as playlist}
            {#if filteredSearchTerm == ''}
                <PlaylistThumbnail playlistInfo={playlist} />
            {:else if playlist.name.toLowerCase().includes(filteredSearchTerm.toLowerCase())}
                <PlaylistThumbnail playlistInfo={playlist} />
            {/if}
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