<script lang="ts">
import type {SimplePlaylist} from "../tssrc/types"

let {playlistInfo} : {playlistInfo: SimplePlaylist} = $props();
let playlistLink = $state("http://localhost:5173/playlist/" + playlistInfo.spotifyUri)
</script>

<div class="playlist-card">
    <img src={playlistInfo.imageUrl} alt="Album Art" class="playlist-image"/>
    <div class="track-details">
        <p class="playlist-name"><a href={playlistLink}>{playlistInfo.name}</a></p>
    </div>
</div>

<style>
    a{
        color: white;
        text-decoration: underline;
        text-decoration-color: white;
        font-family: "Helvetica Neue", sans-serif;
        font-weight: bold;
    }
    .playlist-card {
        display: flex;
        align-items: center;
        width:100%;
        height: 5em;
        gap: 0.5rem;
        background-color: #282828;
        padding: 0.5em;
        border-radius: 8px;
        max-width: 400px;
        font-family: "Helvetica Neue", sans-serif;
        color: white;
        margin: 0.5em 0 0.5em 0
    }
    .playlist-image {
        width: 64px;
        height: 64px;
        border-radius: 4px;
    }
    .playlist-name {
        font-weight: bold;
        margin: 0;
    }
</style>