<script>
    import UserPlaylists from "$lib/components/spotify-components/UserPlaylists.svelte"
    import HomeBar from "$lib/components/HomeBar.svelte"

    let { data } = $props();
</script>

<HomeBar userData={data.userData} colors={data.colors} />
<div class="w-full h-full flex flex-col gap-12 pt-4 pb-4 pr-48 pl-48">
</div>
