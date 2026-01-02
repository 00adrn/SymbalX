<script>
    import PlaylistContainer from "$lib/components/PlaylistContainer.svelte";

    let colors = ["#252530", "#2e2d38"];
    let deg = 22.5;

    let { data } = $props();
</script>

<div class="body" style="--deg: {deg}deg; --gradient-1: {colors[0]}; --gradient-2: {colors[1]};">
    <h1>Home page of symbalx</h1>
    {#if data.isLoggedIn}
        <div class="plc-container">
            <PlaylistContainer playlists={data.playlists}/>
        </div>
    {:else}
        <p>You are not logged in</p>
    {/if}
</div>

<style>
    .body{
        background: linear-gradient(var(--deg),var(--gradient-1), var(--gradient-2));
    }
    .plc-container{
        width: 50%;
        
        display: flex;
        flex-direction: row;
    }
</style>
