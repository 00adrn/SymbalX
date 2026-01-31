<script>

    let { text, href } = $props();
</script>

<button class="w-24 h-10 rounded-full bg-gray-300 border-gray-400 border font-bold text-white hover:bg-gray-400">
    <a {href} class="w-24 h-10 rounded-full flex justify-center items-center">
        {text}
    </a>
</button>
