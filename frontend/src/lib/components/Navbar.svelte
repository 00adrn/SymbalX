<script>
    import NavButton from "$lib/components/NavButton.svelte"

    let { data} = $props();
</script>

<div class="w-screen flex flex-row items-center justify-between p-4">
    <div>
        <p><a class="" href="/">symbalx</a></p>
    </div>

    <div class="flex flex-row gap-x-4 ">
        {#if data.session}
            <div><NavButton  text="Profile" href="/profile" /></div>
        {:else}
            <div><NavButton text="Login" href="/auth/login"/> </div>
        {/if}

        <div><NavButton text="Home" href="/home" /></div>
    </div>
</div>

