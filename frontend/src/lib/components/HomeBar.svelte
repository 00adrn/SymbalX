<script>
    import CurrentTrack from "$lib/components/spotify-components/CurrentTrack.svelte"
    let { colors, userData } = $props();


</script>

<div class="body">
        <div class="body-left">
            <img src={userData.img} alt="pfpimg"/>
        </div>
        <div class="body-right">
            <div class="current-track">
                <CurrentTrack colors={colors} userData={userData} />
            </div>
        </div>
    </div>
