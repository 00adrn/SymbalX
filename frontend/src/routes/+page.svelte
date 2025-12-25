<script lang="ts">
    import { api } from "$lib/api/api";
    import { onMount } from "svelte";
    import type { Track } from "$lib/api/types"
    let track : Track | undefined = $state();
    onMount(async () =>{
        track = await api.getCurrentTrack();
    });

    function test() {
        window.location.href = "/auth/login";
    }
</script>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>

<button onclick={test}> click me</button>
{#if track == null}
    <p>Loading</p>
{:else}
    <p>{track.name}</p>
{/if}
