<script lang="ts">
    import type { PageProps } from "./$types"

    let { data }: PageProps = $props();
</script>

<h1>Profile page</h1>

{#if data.profile}
    <h2>Logged in as {data.profile.name}</h2>
{:else}
    <h2>You are not currently logged in</h2>
{/if}
