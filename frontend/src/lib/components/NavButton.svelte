<script>
 let { data, text, href } = $props();
</script>

<div class="button-body" style="--color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <a {href} >{text}</a>
</div>

<style>
    .button-body {
        display: flex;
        justify-content: center;
        align-items: center;
        min-width: 5rem;
        height: 2.2rem;
        background-color: transparent;
        border: 1px solid gray;
        border-radius: .4rem;
    }
    .button-body:hover {
        background-color: var(--color-2);
    }
    .button-body a {
        height: 100%;
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        border-radius: .4rem;
        color: white;
        font-size: 1.2rem;
        text-decoration: none;
    }

</style>