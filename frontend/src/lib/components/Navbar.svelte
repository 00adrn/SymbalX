<script>
    let { isLoggedIn } = $props();

</script>

<div class="nav">
    <ul>
        {#if isLoggedIn}
            <li><a href="/profile">Profile</a></li>
        {:else}
            <li><a href="/auth/login">Login</a></li>
        {/if}
        <li><a href="/home">Home</a></li>
    </ul>
</div>

<style>
    .nav {
        background-color: grey;
        overflow: hidden;
        display: flex;
        justify-items: space-between;
        align-items: center;
        padding: 0;
        width: 100%;
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
        padding: 2px 10px 2px 0;
        height: 100%;
    }
    .nav a {
        text-decoration: none;
        color: black;
    }
</style>