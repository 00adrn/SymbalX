<script>
    import NavButton from "$lib/components/NavButton.svelte"

    let { data, colors, profileInfo } = $props();
    let deg = 180;
</script>

<div class="nav" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]};">
    <div>
        <p><a class="title-button" href="/home">symbalx</a></p>
    </div>
    <ul>
        {#if data.isLoggedIn}
            <li><div class="nav-item nav-profile">
                <a class="nav-img" href="/profile"> <img class="nav-img" src={profileInfo.images[0].url} alt="profileImg"/></a>
            </div></li>
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
        border: solid gray;
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
    .nav ul a {
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .nav ul li {
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .nav .nav-item {
        text-decoration: none;
        color: white;
        font-size: 1.4rem;
    }
    .nav .nav-img {
        width: 2.4rem;
        height: 2.4rem;
        border-radius: 50%;
        border: 1px solid gray;
    }
    .nav .nav-profile {
        display: flex;
        flex-direction: row;
        align-items: center;
        gap: .6rem;
    }
    .nav .nav-profile a{
        text-decoration: none;
        color: white;
        font-size: 1.4rem;
    }
</style>