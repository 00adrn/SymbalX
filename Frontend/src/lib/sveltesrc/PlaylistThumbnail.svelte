<script lang="ts">
import type {SimplePlaylist} from "../tssrc/types"

let {playlistInfo} : {playlistInfo: SimplePlaylist} = $props();
</script>

<div class="playlist-card">
    <img src={playlistInfo.imageUrl} alt="Album Art" class="playlist-image"/>
    <div class="track-details">
        <p class="playlist-name">{playlistInfo.name}</p>
    </div>
</div>

<style>
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
    }
    .playlist-image {
        width: 64px;
        height: 64px;
        border-radius: 4px;
    }
    .track-details {
        display: flex;
        flex-direction: column;
        align-items: start;
        text-wrap: nowrap;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }
    .playlist-name {
        font-weight: bold;
        margin: 0;
    }
</style>