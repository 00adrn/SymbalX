<script lang="ts">
    import type { Playlist } from "$lib/api/types";

    let { playlist }: { playlist: Playlist } = $props();
</script>

<div class="playlist-card">
    <img src={playlist.imageUrl} alt={playlist.name} />
    <p>{playlist.name}</p>
</div>

<style>
    .playlist-card {
        display: flex;
        flex-direction: row;
        gap: 1rem;
        align-items: center;
        background-color: gray;
        width: 20rem;
        border-radius: 0.4rem;
    }
    .playlist-card img {
        width: 5.6rem;
        height: 5.6rem;
        border-radius: 0.4rem 0 0 0.4rem;
    }
    .playlist-card p {
        font-size: 1.2rem;
        color: white;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        min-width: 0;
    }
</style>
