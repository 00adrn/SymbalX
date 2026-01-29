<script>
    import LoginForm from "$lib/components/auth/LoginForm.svelte";
    
    let { data } = $props();
    let deg = 22.5;
    
</script>

<div class="body" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <div class="component-container">
        <LoginForm />
    </div>
</div>
