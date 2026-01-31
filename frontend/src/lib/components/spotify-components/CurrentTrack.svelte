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

<div class="w-full h-full flex flex-row items-center gap-6 bg-transparent">
    <div class="">
        {#if track}
            <img src={track.album.images[0].url} alt="Track Cover" class="w-28 h-28"/>
        {/if}
    </div>
    <div class="flex flex-col gap-2 pr-4 truncate">
        <p class="text-black font-semibold">Currently listening to:</p>
        <p class="text-black font-bold text-3xl">
            {#if track} 
                {track.name}
            {:else}
                No track playing
            {/if}
        </p>
        <div class="flex flex-row gap-2 text-white font-semibold text-xl ">
            {#if track}
                <p class="text-black">by</p>
                {#each track.artists as artist, i}
                    {#if i == track.artists.length - 1}
                        {#if track.artists.length > 1}
                            <p class="text-black">and</p>
                        {/if}
                        <p class="text-black">{artist.name}</p>
                    {:else}
                        {#if track.artists.length != 2}
                            <p class="text-black">{artist.name},</p>
                        {:else}
                            <p class="text-black">{artist.name}</p>
                        {/if}
                    {/if}
                {/each}
            {/if}
        </div>
    </div>
</div>
