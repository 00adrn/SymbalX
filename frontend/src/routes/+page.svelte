<script>
    const colors = ["#252530", "#2e2d38", "#232323", "#505052"];
    const deg = 180;

</script>

<div class="body" style="--deg: {deg}deg; --color-0: {colors[0]}; --color-1: {colors[1]}; --color-2: {colors[2]}; --color-3: {colors[3]};">
    <div class="main">
        <p class="main-text">Welcome to symbalx</p>
        <p class="main-subtext">Track your music, share with friends</p>
    </div>
</div>

<style>
    .body {
        height: 100vh;
        background: linear-gradient(var(--deg),var(--color-0), var(--color-1));
        display: flex;
        justify-content: flex-start;
        flex-direction: column;
        gap: 1rem;
        overflow-y: scroll;
        scrollbar-width: .2rem; 
        scrollbar-color: var(--color-0) var(--color-2);
        padding: 2rem;
    }
    .main {
        margin-top: 6rem;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    .main-text {
        color: white;
        text-align: center;
        font-size: 5.6rem;
    }
    .main-subtext {
        color: white;
        text-align: center;
        font-size: 1.6rem;
    }
    .body-row {
        display: flex;
        flex-direction: row;
        gap: 1rem;
    }
    .component-container {
        border-radius: .4rem;
        border: 1px var(--color-3) solid;
        overflow: hidden;
        background-color: var(--color-2)
    }
</style>
