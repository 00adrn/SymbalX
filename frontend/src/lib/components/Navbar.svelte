<script>
    let { data } = $props();

</script>

<div class="nav">
    <div>
        <p>symbalx</p>
    </div>
    <ul>
        {#if data.isLoggedIn}
            <li><a href="/profile">Profile</a></li>
        {:else}
            <li><a href="/auth/login">Login</a></li>
        {/if}
        <li><a href="/home">Home</a></li>
    </ul>
</div>

<style>
    .nav {
        position: fixed;
        background-color: grey;
        overflow: hidden;
        display: flex;
        flex-direction: row;
        justify-items: space-between;
        align-items: center;
        padding: 0;
        width: 100%;
        border: solid black;
        border-width: 0.01rem 0;
    }
    .nav ul {
        width: 100%;
        list-style: none;
        display: flex;
        justify-content: flex-end;
        align-items: center;
    }
    .nav li {
        font-size: 2.4rem;
        padding: .2rem 1rem .2rem 0;
        height: 100%;
    }
    .nav a {
        text-decoration: none;
        color: black;
    }
    .nav p {
        padding: .2rem 1rem;
        font-size: 2.4rem;
    }
</style>