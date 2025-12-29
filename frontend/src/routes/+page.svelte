<script lang="ts">
    import { api } from "$lib/api/api";
    import { onMount } from "svelte";
    import type { Track } from "$lib/api/types"
    let track : Track | undefined = $state();
    let testTrack : Track | undefined = $state();
    let isLoggedIn = $state(false);
    onMount(async () => {
        const resp = await fetch("/auth/status", {
            method: "GET",
            credentials: "include"});

        const data = await resp.json();

        if (data != "null")
            isLoggedIn = true;

        let trackresp = await fetch("/api/current-track", {
            method: "GET",
            credentials: "include"
        });
        
        track = await trackresp.json();

        let testTrackresp = await (fetch("/api/get-info?type=track&uri=0symmj4uSnBmiMblgJb5BZ", {
            method: "GET",
            credentials: "include"
        }))

        testTrack = await testTrackresp.json();
    });

    function test() {
        window.location.href = "/auth/login";
    }
</script>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>

{#if isLoggedIn}
    <p>You are logged in</p>
{:else}
    <p>You are not logged in</p>
{/if}

<button onclick={test}> click me</button>
{#if track == null}
    <p>Loading</p>
{:else}
    <p>{track.name}</p>
{/if}   

{#if testTrack == null}
    <p>Loading</p>
{:else}
    <p>{testTrack.name}</p>
{/if}
