<script>
    import { onMount } from "svelte"

    const { colors, userData } = $props();
    const deg = 22.5;

    let track = $state();

    onMount(async () => {
        const resp = await fetch("/api/user/get-current-track", {
            method: "GET",
            headers: {
                Authorization: "Bearer " + userData.sp_access_token
            }
        })

        const trackData = await resp.json();
        if (resp.ok && trackData.item)
            track = trackData.item;
    });
</script>

<div class="track-card" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]}; --color-2: {colors[2]}; --color-3: {colors[3]};">
    <div class="track-img">
        {#if track}
            <img src={track.album.images[0].url} alt="Track Cover"/>
        {/if}
    </div>
    <div class="track-text">
        <p class="current-text">Currently listening to:</p>
        <p class="track-name">
            {#if track} 
                {track.name}
            {:else}
                No track playing
            {/if}
        </p>
        <div class="track-artist">
            {#if track}
                {#each track.artists as artist, i}
                    {#if i == track.artists.length - 1}
                        <p>{artist.name}</p>
                    {:else}
                        <p>{artist.name},</p>
                    {/if}
                {/each}
            {/if}
        </div>
    </div>
</div>
