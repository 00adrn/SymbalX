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

<style>
    .playlist-container {
        background-color: var(--color-2);
        display: flex;
        flex-direction: column;
        align-items: center;
        height: 40rem;
        width: 100%;
    }
    .playlist-container .card-container {
        margin: .4rem;
        padding-left: .4rem;
        padding-right: .4rem;
        width: 100%;
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        overflow-y: scroll;
        gap: .4rem;
        scrollbar-width: .2rem; 
        scrollbar-color: var(--color-1) transparent;

    }
    .card-container::-webkit-scrollbar-track {
        background: transparent;
    }
    .card-container::-webkit-scrollbar-thumb {
        border-radius: .4rem;
        background-clip: content-box;
    }
    .card-container::-webkit-scrollbar-button {
        display: none;
    }
</style>