<script lang="ts">
    import PlaylistCard from "$lib/components/PlaylistCard.svelte";


    let {playlists } = $props();
</script>

<div class="playlist-container">
    <div class="card-container">
        {#each playlists as playlist}
            <PlaylistCard playlist={playlist} />
        {/each}
    </div>
</div>

<style>
    .playlist-container {
        background-color: #232323;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        max-height: 40rem;
        width: 100%;
        overflow-y: scroll;
        border-radius: .4rem;
    }
    .playlist-container .card-container {
        padding: .4rem;
        width: 100%;
        display: flex;
        flex-direction: column;
        gap: .4rem;
    }
</style>