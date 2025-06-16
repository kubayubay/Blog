<template>
    <div>
        <div class="text-4xl font-bold mb-4 italic">
            Blog Posts
        </div>
        <div v-if="posts != undefined">
            <Post v-for="post in posts" :key="post.id" :post="post" class="mb-4" />
        </div>
    </div>
</template>

<script setup lang="ts">
const posts = ref()

$fetch('/api/v1/Blog/Posts', {
    server: false,
    onResponse({ response }) {
        posts.value = response._data
    }
})
</script>