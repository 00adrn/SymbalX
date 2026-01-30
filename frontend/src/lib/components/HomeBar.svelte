<script>
    import CurrentTrack from "$lib/components/spotify-components/CurrentTrack.svelte"
    let { colors, userData } = $props();


</script>

<div class="w-full flex flex-row justify-between items-center border-b-1 border-gray-600 pl-4 pr-4 pb-2 pt-2 bg-gray-900">
        <div class="">
            <img src={userData.img} alt="pfpimg" class="w-36 h-36 rounded-full"/>
        </div>
        <div class="w-1/4 h-full flex flex-row justify-left overflow">
            <CurrentTrack colors={colors} userData={userData} />
        </div>
    </div>
