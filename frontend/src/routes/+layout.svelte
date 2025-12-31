<script lang="ts">
    import favicon from "$lib/assets/favicon.svg";
    import Navbar from "$lib/components/Navbar.svelte";
    import { onMount } from "svelte";
    import "../styles.css";

    let { children, data } = $props();
</script>

<svelte:head>
    <link rel="icon" href={favicon} />
</svelte:head>

<Navbar {data}/>

{@render children()}
