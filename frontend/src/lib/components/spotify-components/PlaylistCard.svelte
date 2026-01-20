<script lang="ts">
    const deg = 22.5
    let { playlist, colors } = $props();
</script>

<div class="playlist-card" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]}; --color-2: {colors[2]}; --color-3: {colors[3]};">
    <img src={playlist.images[0].url} alt="Playlist Cover" />
    <p>{playlist.name}</p>
</div>

<style>
    .playlist-card {
        display: flex;
        flex-direction: row;
        width: 100%;
        gap: 1rem;
        height: 4rem;
        align-items: center;
        background: linear-gradient(var(--deg),var(--color-0), var(--color-1));
        border-radius: .4rem;
    }
    .playlist-card img {
        width: 4rem;
        height: 4rem;
        border-radius: .4rem 0 0 .4rem;
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
