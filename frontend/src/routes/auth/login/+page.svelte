<script>
    import LoginRegisterForm from "$lib/components/auth/LoginRegisterForm.svelte";
    
    let { data } = $props();
    let deg = 22.5;
    
</script>

<div class="body" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <div class="component-container">
        <LoginRegisterForm />
    </div>
</div>

<style>
    .body {
        padding: 2rem;
        height: 100vh;
        background: linear-gradient(var(--deg),var(--color-0), var(--color-1));
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        gap: 1rem;
        overflow-y: scroll;
        scrollbar-width: .2rem; 
        scrollbar-color: var(--color-0) var(--color-2);
    }
    .component-container {
        width: 50%;
        height: auto;
        border-radius: .4rem;
        border: 1px gray solid;
        overflow: hidden;
    }
</style>