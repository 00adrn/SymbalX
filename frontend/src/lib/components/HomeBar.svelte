<script>

    let { userData } = $props();

</script>

<div class="body">
    {#if userData.profile_image}
        <img src={userData.img} alt="pfpimg"/>
    {/if}
</div>

<style>
    .body {
        width: 100%;
        height: 8rem;
        background: black;
        display: flex;
        flex-direction: row;
        align-items: center;
    }

    .body img {
        width: 6rem;
        height: 6rem;
        border-radius: 50%
    }

</style>