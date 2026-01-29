<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte"
    import HomeBar from "$lib/components/HomeBar.svelte"

    let deg = 180;

    let { data } = $props();
</script>

<div class="body" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]}; --color-3: {data.colors[3]};">
    <div class="body-row">
        <HomeBar userData={data.userData} colors={data.colors} />
    </div>

    <div class="body-row">
        <div class="component-container">
            {#if data.userData.sp_access_token}
                <UserPlaylists colors={data.colors} userPlaylists={data.playlists} />
            {/if}
        </div>
    </div>
</div>
