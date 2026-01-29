<script>
  import NavButton from "$lib/components/NavButton.svelte";

  let { data } = $props();
</script>

<div
  class="w-full flex flex-row items-center justify-between sticky top-0 p-4 bg-gray-500/75"
>
  <div>
    <p class="text-4xl font-extrabold"><a class="" href="/">symbalx</a></p>
  </div>

  <div class="flex flex-row gap-x-2">
    {#if data.session}
      <div><NavButton text="Profile" href="/profile" /></div>
    {:else}
      <div><NavButton text="Login" href="/auth/login" /></div>
    {/if}

    <div><NavButton text="Home" href="/home" /></div>
  </div>
</div>
