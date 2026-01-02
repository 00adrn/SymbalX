<script lang="ts">
    import type { Playlist } from "$lib/api/types";

    let colors = ["#252530", "#2e2d38"];
    let deg = 22.5;

    let { playlist }: { playlist: Playlist } = $props();
</script>

<div class="playlist-card" style="--deg: {deg}deg; --gradient-1: {colors[0]}; --gradient-2: {colors[1]};">
    <img src={playlist.imageUrl} alt={playlist.name} />
    <p>{playlist.name}</p>
</div>

<style>
    .playlist-card {
        display: flex;
        flex-direction: row;
        width: 100%;
        gap: 1rem;
        align-items: center;
        background: linear-gradient(var(--deg),var(--gradient-1), var(--gradient-2));
        border-radius: 0.4rem;
        /* border: 0.01rem solid white; */
    }
    .playlist-card img {
        width: 4rem;
        height: 4rem;
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
