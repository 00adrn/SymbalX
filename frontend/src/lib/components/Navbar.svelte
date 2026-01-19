<script>
    import NavButton from "$lib/components/NavButton.svelte"

    let { data} = $props();
    let deg = 180;

</script>

<div class="nav" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]}; --color-3: {data.colors[3]};">
    <div>
        <p><a class="title-button" href="/home">symbalx</a></p>
    </div>
    <ul>
        {#if data.session}
            <li><NavButton data={data} text="Profile" href="/profile" /></li>
        {:else}
            <li><NavButton data={data} text="Login" href="/auth/login"/> </li>
        {/if}

        <li><NavButton data={data} text="Home" href="/home" /></li>
    </ul>
</div>

<style>
    .nav {
        position: sticky;
        top: 0;
        background: linear-gradient(var(--deg),var(--color-1), var(--color-0));
        overflow: hidden;
        display: flex;
        flex-direction: row;
        justify-items: space-between;
        align-items: center;
        color: white;
        border: solid var(--color-3);
        border-width: 1px 0;
    }
    .nav ul {
        width: 100%;
        list-style: none;
        display: flex;
        justify-content: flex-end;
        align-items: center;
        margin-right: 1rem;
        gap: 1.2rem;
    }
    .nav .title-button {
        text-decoration: none;
        color: white;
        padding: 1rem;
        font-size: 2.4rem;
    }
</style>