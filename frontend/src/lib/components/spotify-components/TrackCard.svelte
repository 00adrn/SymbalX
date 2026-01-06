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

<style>
    .track-card {
        display: flex;
        flex-direction: row;
        align-items: center;
        width: 100%;
        height: 4rem;
        gap: 1rem;
        background: linear-gradient(var(--deg),var(--color-0), var(--color-1));
        border-radius: .4rem;
        border: 1px solid gray;
    }
    .track-card img {
        width: 4rem;
        height: 4rem;
        border-radius: .4rem 0 0 .4rem;
    }
    .track-card .track-text{
        font-size: 1.2rem;
        color: white;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        min-width: 0;
    }
    .track-card .track-text .track-artist {
        display: flex;
        flex-direction: row;
        gap: .4rem;
        padding-left: .4rem;
    }
    .track-card .track-text .track-artist p {
        font-size: .8rem;
    }

</style>