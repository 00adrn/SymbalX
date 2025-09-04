<script lang="ts">
    import { spotifyBE } from "../tssrc/apiRequests";
    import type { Track } from "../tssrc/types";

    let buttonPressed = $state(false);

    async function getTrackInfo(): Promise<Track | null> {
        return await spotifyBE.fetchCurrentTrackInfo();
    }

    function buttonPress() {
        buttonPressed = true;
    }
</script>

{#if !buttonPressed}
    <button onclick={buttonPress}>Get Current Track</button>
{:else}
    {#await getTrackInfo()}
        <p>Fetching track info...</p>
    {:then trackInfo}
        {#if trackInfo}
            <div class="track-card">

                <img
                    src={trackInfo.imageUrl}
                    alt="Album art for {trackInfo.name}"
                    class="album-art"
                />
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
        {:else}
            <p>No track is currently playing.</p>
        {/if}
    {:catch error}
        <p style="color: #f87171;">Error fetching track: {error.message}</p>
    {/await}
{/if}

<style>
    .track-card {
        display: flex;
        align-items: center;
        gap: 1rem;
        background-color: #282828;
        padding: 1rem;
        border-radius: 8px;
        max-width: 400px;
        margin: 1rem auto;
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
    }
    .track-name {
        font-weight: bold;
        margin: 0;
    }
    .artist-name {
        color: #b3b3b3;
        margin: 0.25rem 0 0;
        display: flex;
        flex-direction: row;
    }
    .artist-name-comma {
        color: #b3b3b3;
        margin: 0.25rem 0 0;
        display: flex;
        flex-direction: row;
        padding-right: 0.25em;
    }
    .artist-box {
        display: flex;
        flex-direction: row;
    }
</style>
