<script lang="ts">

    let {track, colors} = $props();
</script>

<div class="track-card">
    <img />
    <div>
        <p class="track-name"> </p>
        <div>
            {#each track.artists as artist, i}
                {#if i == track.artists.length - 1}
                    <p class="artist-name">{artist.name}</p>
                {:else}
                    <p class="artist-name">{artist.name}, </p>
                {/if}
            {/each}
        </div>
    </div>
</div>

<style>
    .track-card {
        display: flex;
        flex-direction: row;
        width: 100%;
        gap: 1rem;
    }
</style>