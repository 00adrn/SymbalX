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
        padding: 4px;
        font-size: 12px;
        font-family: sans-serif;
        font-weight: bold;
        letter-spacing: 2px;
        margin-left: 4px;
        margin-right:  4px;
        }
    .profile-card-text{
        margin-left: 4px;
    }
    .profile-card-picture {
        margin-right: 4px;
        border-radius: 50%;
        max-width: 3em;
        max-height: 3em;
        }
</style>