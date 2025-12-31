<script>
    import PlaylistContainer from "$lib/components/PlaylistContainer.svelte";

    let { data } = $props();
</script>

<div class="body">
    <h1>Home page of symbalx</h1>
    {#if data.isLoggedIn}
        <PlaylistContainer playlists={data.playlists} />
    {:else}
        <p>You are not logged in</p>
    {/if}
</div>

<style>
</style>
