<script lang="ts">
    import PlaylistCard from "$lib/components/spotify-components/PlaylistCard.svelte";

    let { userPlaylists, colors } = $props();
</script>

<div class="w-full h-full rounded-2xl bg-transparent border-1 border-gray-300">
    <div class="w-full h-full flex flex-col gap-y-2 p-2 overflow-y-scroll" >
        {#each userPlaylists.items as playlist}
            <PlaylistCard playlist={playlist} />
        {/each}
    </div>
</div>

