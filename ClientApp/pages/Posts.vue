<template>
    <div>
        <div class="text-4xl font-bold mb-4 italic">
            Blog Posts
        </div>
        <div v-if="posts != undefined">
            <Post v-for="post in posts" :key="post.id" :post="post" class="mb-4" @delete="onDelete" />
        </div>
    </div>
</template>

<script setup lang="ts">
const posts = ref()

const reloadAllPosts = () => {
    $fetch('/api/v1/Blog/Posts', {
        server: false,
        onResponse({ response }) {
            posts.value = response._data
        }
    })
}

reloadAllPosts()

const onDelete = () => {
    reloadAllPosts()
}
</script>