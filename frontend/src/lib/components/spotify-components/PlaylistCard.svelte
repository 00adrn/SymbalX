<script lang="ts">
    let { playlist} = $props();
</script>

<div class="w-full h-full display flex flex-row items-center gap-6 bg-gray-900 rounded-2xl border-1 border-gray-600" >
    <img src={playlist.images[0].url} alt="Playlist Cover" class="w-24 h-24 rounded-l-2xl"/>
    <p class="text-2xl font-bold"><a href="/playlists/{playlist.id}">{playlist.name}</a></p>
</div>

