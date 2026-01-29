<script>
    import NavButton from "$lib/components/NavButton.svelte"

    let { data} = $props();
</script>

<div class="w-screen flex flex-row items-center justify-between sticky top-0 pt-2 pb-2 pl-4 pr-4 ">
    <div>
        <p><a class="" href="/">symbalx</a></p>
    </div>

    <div class="flex flex-row gap-x-2 ">
        {#if data.session}
            <div><NavButton  text="Profile" href="/profile" /></div>
        {:else}
            <div><NavButton text="Login" href="/auth/login"/> </div>
        {/if}

        <div><NavButton text="Home" href="/home" /></div>
    </div>
</div>