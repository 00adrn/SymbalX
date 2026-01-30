<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte"
    import HomeBar from "$lib/components/HomeBar.svelte"

    let deg = 180;

    let { data } = $props();
</script>

<HomeBar userData={data.userData} colors={data.colors} />
<div class="w-full h-full flex flex-col gap-4 p-4">
    <div class="h-200 flex flex-row gap-4">
        {#if data.userData.sp_access_token}
            <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
        {/if}
    </div>
    <div class="h-200 flex flex-row gap-4">
        {#if data.userData.sp_access_token}
            <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
        {/if}
    </div>
    <div class="h-200 flex flex-row gap-4">
        {#if data.userData.sp_access_token}
            <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
        {/if}
    </div>
    <div class="h-200 flex flex-row gap-4">
        {#if data.userData.sp_access_token}
            <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
        {/if}
    </div>
    
</div>
