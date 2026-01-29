<script lang="ts">
    import PlaylistCard from "$lib/components/spotify-components/PlaylistCard.svelte";

    let { userPlaylists, colors } = $props();
</script>

<div class="playlist-container" style="--color-0: {colors[0]}; --color-1: {colors[1]}; --color-2: {colors[2]};">
    <div class="card-container" >
        {#each userPlaylists.items as playlist}
            <PlaylistCard playlist={playlist} colors={colors} />
        {/each}
    </div>
</div>

