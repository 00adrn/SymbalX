<script lang="ts">

    interface Track{
        spotifyUri: string;
        name: string;
        imageUrl: string;
    }

    let  { uri = "7o2AeQZzfCERsRmOM86EcB"} = $props();

    async function fetchTrack(trackUri: string): Promise<Track> {

        const response = await fetch('/api/spotify:track:${encodeURIComponent(trackUri)}')

        if (!response.ok)
            throw new Error('Failed to fetch track. stats: ${response.status}');

            const data = await response.json();

            return {
                spotifyUri: data.uri,
                name: data.name,
                imageUrl: data.album.images[0].url
            };

    }

    const trackPromise = fetchTrack(uri);

</script>

{#await trackPromise}
    <div class="track-card loading">
        <p>Loading track...</p>
    </div>
{:then track}
    <div class="track-card">
        <img src={track.imageUrl} alt="Album art for {track.name}" />
        <div class="track-info">
            <p class="track-name">{track.name}</p>
        </div>
    </div>
{:catch error}
    <div class="track-card error">
        <p>Could not load track.</p>
        <pre>{error.message}</pre>
    </div>
{/await}

<style>
    .track-card {
        display: flex;
        align-items: center;
        gap: 1rem;
        background-color: #282828;
        padding: 0.75rem;
        border-radius: 4px;
        max-width: 350px;
        margin: 0.5rem auto;
        font-family: sans-serif;
    }

    .track-card.loading, .track-card.error {
        justify-content: center;
        color: #b3b3b3;
    }

    .track-card.error {
        border: 1px solid #d9534f;
        color: #d9534f;
        flex-direction: column;
    }

    .track-card img {
        width: 64px;
        height: 64px;
        border-radius: 4px;
        object-fit: cover;
    }

    .track-info {
        overflow: hidden;
    }

    .track-name {
        font-weight: bold;
        color: #fff;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        margin: 0;
    }

</style>
