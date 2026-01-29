<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte"
    import HomeBar from "$lib/components/HomeBar.svelte"

    let deg = 180;

    let { data } = $props();
</script>

<div class="">
    <div class="">
        <HomeBar userData={data.userData} colors={data.colors} />
    </div>

    <div class="">
        <div class="">
            {#if data.userData.sp_access_token}
                <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
            {/if}
        </div>
    </div>
</div>
