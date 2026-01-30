<script lang="ts">

    let {track, colors} = $props();
    let deg = 22.5;
</script>

<div class="">
    <img src={track.album.images[0].url} alt="Track Cover"/>
    <div class="">
        <p class="">{track.name}</p>
        <div class="">
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
