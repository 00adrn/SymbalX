<script>
    import RegisterForm from "$lib/components/auth/RegisterForm.svelte";
    
    let { data } = $props();
    let deg = 22.5;
    
</script>

<div class="body" style="--deg: {deg}deg; --color-0: {data.colors[0]}; --color-1: {data.colors[1]}; --color-2: {data.colors[2]};">
    <div class="component-container">
        <RegisterForm  { data }/>
    </div>
</div>

