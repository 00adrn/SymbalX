<script>
    let { data, colors } = $props();
    let deg = 180;


</script>

<div class="nav" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]};">
    <div>
        <p><a class="title-button" href="/home">symbalx</a></p>
    </div>
    <ul>
        {#if data.isLoggedIn}
            <li><a class="nav-button" href="/profile">Profile</a></li>
        {:else}
            <li><a class="nav-button" href="/auth/login">Login</a></li>
        {/if}
        <li><a class="nav-button" href="/home">Home</a></li>
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
    }
    .nav .title-button {
        text-decoration: none;
        color: white;
        padding: 1rem;
        font-size: 2.4rem;
    }
    .nav .nav-button {
        text-decoration: none;
        color: white;
        padding: 0 2rem 0 0;
        font-size: 1.4rem;
    }
</style>