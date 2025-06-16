<template>
    <div>
        <label>Type in a title:</label>
        <input type="text" v-model="post.title" name="title" class="border ml-4 rounded w-1/2" />

        <div>
            <label class="block">Type in your blog post:</label>
            <textarea v-model="post.content" class="border w-full h-32 rounded" />
        </div>

        <button class="bg-blue-500 py-1 px-2 hover:cursor-pointer hover:bg-blue-700 rounded-lg shadow-lg font-semibold text-white mb-4" @click="onClickSubmit">
            Submit Blog Post
        </button>
    </div>
</template>

<script setup lang="ts">
const post = ref({
    title: '',
    content: ''
})

const onClickSubmit = () => {
    $fetch('/api/v1/Blog/Post', {
        server: false,
        method: 'POST',
        body: post,
        onResponse({ response }) {
            // fill this later
        }
    })
}
</script>