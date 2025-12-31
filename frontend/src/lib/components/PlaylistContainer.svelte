<script lang="ts">
    import PlaylistCard from "$lib/components/PlaylistCard.svelte";


    let {playlists } = $props();
</script>

<div class="playlist-container">
    {#each playlists as playlist}
        <PlaylistCard playlist={playlist} />
    {/each}
</div>