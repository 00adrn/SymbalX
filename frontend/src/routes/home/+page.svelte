<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte";
    import TrackCard from "$lib/components/spotify-components/TrackCard.svelte"
    let deg = 180;

    let { data } = $props();
</script>

<div class="body" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <div class="body-row">
        <div class="component-container">
            
        </div>
    </div>
</div>

<style>
    .body {
        padding: 2rem;
        height: 100vh;
        background: linear-gradient(var(--deg),var(--color-0), var(--color-1));
        display: flex;
        justify-content: flex-start;
        flex-direction: column;
        gap: 1rem;
        overflow-y: scroll;
        scrollbar-width: .2rem; 
        scrollbar-color: var(--color-0) var(--color-2);
    }
    .body-row {
        display: flex;
        flex-direction: row;
        gap: 1rem;
    }
    .component-container {
        border-radius: .4rem;
        border: 1px gray solid;
        overflow: hidden;
    }
</style>
