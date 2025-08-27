<script lang="ts">
    interface Track{
        spotifyUri: string;
        name: string;
        imageUrl: string;
    }

    async function fetchTrack(): Promise<Track>{
        const response = await fetch('[::1]:5157/spotify/track/' + uri);

        const data = await response.json();

        return {
            spotifyUri: data.spotifyUri,
            name: data.name,
            imageUrl: data.imageUrl
        };
    }


</script>