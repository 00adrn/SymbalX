<script lang="ts">
  import TrackCard from './lib/sveltesrc/TrackCard.svelte'
  import NavBar from './lib/sveltesrc/NavBar.svelte'
  import PlaylistCard from './lib/sveltesrc/PlaylistCard.svelte';
  import UserPlaylists from './lib/sveltesrc/UserPlaylists.svelte';

</script>

<main>
  <NavBar />
  <div class="gap"></div>
  <UserPlaylists />
</main>

<style>
  .gap {
    margin: 2em;
  }
</style>
