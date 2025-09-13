<script lang="ts">
  import TrackCard from './lib/sveltesrc/TrackCard.svelte'
  import NavBar from './lib/sveltesrc/NavBar.svelte'
  import PlaylistCard from './lib/sveltesrc/PlaylistCard.svelte';
  import UserPlaylists from './lib/sveltesrc/UserPlaylists.svelte';
  import SearchBar from './lib/sveltesrc/SearchBar.svelte';
  import getSearchTerm from './lib/sveltesrc/SearchBar.svelte';

  let searchTerm = $state('');
  $inspect(searchTerm).with(console.log);
</script>

<main>
  
  <NavBar />
  <div class="gap"></div>

  <div class="gap"></div>
  <div class="search-bar">
    <input class="search-bar-input" 
        placeholder="search..."
        bind:value={searchTerm}/>
  </div>
  <div class="playlists">
    <UserPlaylists filteredSearchTerm={searchTerm}/> 
  </div>
</main>

<style>
  main{
    display: block;
  }
  .gap {
    margin: 3em;
  }
  .search-bar {
        height: 1.5em;
        width: 8em;
        margin: 0.5em;
    }
    .search-bar input{
        height: 100%;
        width: 100%;
        border-radius: 1.25em;
        border: 0.1em;
        padding: 0.25em;
        text-align: left;
        font-family: "Helvetica Neue", sans-serif;
        font-size: 1em;
        padding:.25em .75em .25em .75em;
    }

</style>
