<script>
    import CurrentTrack from "$lib/components/spotify-components/CurrentTrack.svelte"
    let { colors, userData } = $props();


</script>

<div class="body">
    <img src={userData.img} alt="pfpimg"/>
    <div class="current-track">
        <CurrentTrack colors={colors} userData={userData} />
    </div>
</div>

<style>
    .body {
        width: 100%;
        height: 8rem;
        background: black;
        display: flex;
        flex-direction: row;
        align-items: center;
        padding: 1rem;
        gap: 1rem;
    }

    .body img {
        width: 6rem;
        height: 6rem;
        border-radius: 50%
    }

    .current-track {
        width: auto;
    }

</style>