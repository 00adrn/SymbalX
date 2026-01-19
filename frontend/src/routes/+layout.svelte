<script lang="ts">
    import favicon from "$lib/assets/favicon.svg";
    import Navbar from "$lib/components/Navbar.svelte";
    import "@fontsource-variable/nunito-sans"
    import "../styles.css";
    let { children, data } = $props();
</script>

<svelte:head>
    <link rel="icon" href={favicon} />
</svelte:head>

<Navbar data={data} />

{@render children()}

<style>
    :global(html) {
        font-family: "Nunito Sans Variable", sans-serif;
        font-weight: bold;
    }
</style>