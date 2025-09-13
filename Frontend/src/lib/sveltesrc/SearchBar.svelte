<script lang="ts">
    let searchTerm = $state('');

    function getSearchTerm() {
        return searchTerm;
    }

    export {getSearchTerm}

    $inspect(searchTerm).with(console.log)

</script>

<div class="search-bar">
    <input class="search-bar-input" 
        placeholder="joeingels"
        bind:value={searchTerm}/>
</div>

<style>
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