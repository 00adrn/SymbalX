<script lang="ts">
    const deg = 22.5
    let { playlist, colors } = $props();
</script>

<div class="playlist-card" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]};">
    <img src={playlist.imageUrl} alt="Playlist Cover" />
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
        border: solid gray;
        border-width: 0 1px 1px 0;
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
