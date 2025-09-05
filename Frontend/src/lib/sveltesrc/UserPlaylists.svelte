<script lang="ts">
    import {authenticator} from "../sveltejssrc/logInInfo.svelte.js"
    import {spotifyApi} from "../tssrc/apiRequests"

    import PlaylistThumbnail from "./PlaylistThumbnail.svelte"


</script>

{#if authenticator.checkLoginStatus()}
    {#await spotifyApi.fetchAllUserPlaylists()}
        <p>Loading...</p>
    {:then playlists}
        {#each playlists as playlist}
            <PlaylistThumbnail playlistInfo={playlist} />
        {/each}q
    {/await}
{:else}
    <p>Fetching...</p>
{/if}