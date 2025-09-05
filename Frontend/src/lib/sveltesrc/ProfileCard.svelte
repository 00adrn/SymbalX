<script lang="ts">
    import type {Profile} from "../tssrc/types"
    let { profileInfo } : { profileInfo: Profile|null} = $props();
</script>

{#if profileInfo}
    <div class="profile-card">
        <img class={"profile-card-picture"} src={profileInfo.imageUrl} alt="pfp"/>
        <p class="profile-card-text">{profileInfo.userName}</p>
    </div>
{/if}

<style>
    .profile-card {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: center;
        gap: 0.5em;
        margin: 0 0.5em 0 0.5em;
        }
    .profile-card-text{
        font-size: 1.2em;
        font-family: sans-serif;
        font-weight: bold;
        letter-spacing: 0.1em;
    }
    .profile-card-picture {
        border-radius: 50%;
        width: 2.0em;
        height: 2.0em;
        }
</style>