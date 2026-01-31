<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte"
    import HomeBar from "$lib/components/HomeBar.svelte"

    let deg = 180;

    let { data } = $props();
</script>

<HomeBar userData={data.userData} colors={data.colors} />
<div class="w-full h-full flex flex-col gap-12 pt-4 pb-4 pr-48 pl-48">
    <div class="h-200 flex flex-row gap-4 bg-gray-100 rounded-2xl">
        {#if data.userData.sp_access_token}
            <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
        {/if}
    </div>

</div>
