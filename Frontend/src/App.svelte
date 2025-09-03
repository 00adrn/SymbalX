<script lang="ts">
  import CurrentTrack from './lib/sveltesrc/CurrentTrack.svelte'
  import AuthButton from './lib/sveltesrc/AuthButton.svelte'
  import NavBar from './lib/sveltesrc/NavBar.svelte'


</script>

<NavBar />
<main>
    <AuthButton />
    <hr />
    <h1>Spotify Tracker</h1>
    <hr />
    <CurrentTrack />
</main>

<style>
</style>
