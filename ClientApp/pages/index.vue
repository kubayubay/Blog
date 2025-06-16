<template>
  <div>
    <div class="text-4xl font-bold italic mb-4">
        My Blog
    </div>

    <Form />
  
    <label for="postId">Enter in a blog post #:</label>
    <input type="number" v-model="postId" name="postId" class="border ml-4" />

    <button class="bg-blue-500 py-1 px-2 rounded-lg shadow-lg hover:cursor-pointer hover:bg-blue-700 font-semibold text-white block mb-4" @click="onClickView">
      View Post
    </button>
  
    <Post :post="post" />
  </div>
</template>

<script setup lang="ts">
const postId = ref()
const post = ref()

const onClickView = () => {
  $fetch(`/api/v1/Blog/Post?id=${postId.value}`, {
    server: false,
    onResponse({ response }) {
      post.value = response._data
    }
  })
}
</script>

<style>
</style>