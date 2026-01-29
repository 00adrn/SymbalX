<script lang="ts">
    const deg = 22.5
    let { playlist, colors } = $props();
</script>

<div class="playlist-card" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]}; --color-2: {colors[2]}; --color-3: {colors[3]};">
    <img src={playlist.images[0].url} alt="Playlist Cover" />
    <p>{playlist.name}</p>
</div>

