<script lang="ts">
    import type { PageProps } from "./$types"

    let { data }: PageProps = $props();
</script>

<h1>Profile page</h1>

<h2>Logged in as {data.profile.name}</h2>
