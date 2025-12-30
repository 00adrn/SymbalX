<script lang="ts">
	import favicon from "$lib/assets/favicon.svg";
    import Navbar from "$lib/components/Navbar.svelte"
    import { onMount } from "svelte";
    import "../styles.css"

    let isLoggedIn = $state(false);

    onMount(async () => {
        const resp = await fetch("/auth/status", {
            method: "GET",
            credentials: "include"
        });

        const data = await resp.json();
        if (data != "null")
            isLoggedIn = true;
    });

	let { children } = $props();
</script>

<svelte:head>
	<link rel="icon" href={favicon} />
</svelte:head>

<Navbar isLoggedIn={isLoggedIn} />

{@render children()}