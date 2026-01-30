<script>

    let { text, href } = $props();
</script>

<button class="w-24 h-10 rounded-full bg-gray-900 border-gray-300 border-1 font-bold text-white hover:bg-gray-700">
    <a {href} class="w-24 h-10 rounded-full flex justify-center items-center">
        {text}
    </a>
</button>
