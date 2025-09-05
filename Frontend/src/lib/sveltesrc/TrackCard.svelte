<script lang="ts">
    import type { Track } from "../tssrc/types";

    let{ trackInfo } : { trackInfo: Track } = $props()

</script>

<div class="track-card">
    <img src={trackInfo.imageUrl} alt="Album Art" class="album-art"/>
    <div class="track-details">
        <p class="track-name">{trackInfo.name}</p>
        <div class="artist-box">
            {#each trackInfo.artists as artist}
                <p class="artist-name">{artist.name}</p>
                {#if artist != trackInfo.artists[trackInfo.artists.length - 1]}
                <p class="artist-name-comma">, </p>
                {/if}
            {/each}
        </div>
    </div>
</div>


<style>
    .track-card {
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
    .album-art {
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
    .track-name {
        font-weight: bold;
        margin: 0;
    }
    .artist-name {
        color: #b3b3b3;
        margin: 0.25rem 0 0;
        width: auto;
        display: flex;
        flex-direction: row;
    }
    .artist-name-comma {
        color: #b3b3b3;
        margin: 0.25rem 0 0;
        width: auto;
        display: flex;
        flex-direction: row;
        margin-right: 0.25em;
    }
    .artist-box {
        display: flex;
        flex-direction: row;
        font-size: 0.75em;
    }
</style>
