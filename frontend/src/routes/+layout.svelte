<script lang="ts">
    import "../app.css"
    import favicon from "$lib/assets/favicon.svg";
    import Navbar from "$lib/components/Navbar.svelte";
    import "@fontsource-variable/nunito-sans"
    let { children, data } = $props();
</script>

<svelte:head>
    <link rel="icon" href={favicon} />
</svelte:head>
<div class="bg-black">
    <Navbar data={data} />
    {@render children()}
</div>
