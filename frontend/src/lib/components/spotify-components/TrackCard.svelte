<script lang="ts">

    let {track, colors} = $props();
    let deg = 22.5;
</script>

<div class="track-card" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]};">
    <img src={track.album.images[0].url} alt="Track Cover"/>
    <div class="track-text">
        <p class="track-name">{track.name}</p>
        <div class="track-artist">
            {#each track.artists as artist, i}
                {#if i == track.artists.length - 1}
                    <p>{artist.name}</p>
                {:else}
                    <p>{artist.name},</p>
                {/if}
            {/each}
        </div>
    </div>
</div>
