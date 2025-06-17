<template>
  <div>
    <div class="text-4xl font-bold italic mb-4">
        My Blog
    </div>
  
    <label for="postId">Enter in a blog post #:</label>
    <input type="number" v-model="postId" name="postId" class="border ml-4" />

    <button class="bg-blue-500 py-1 px-2 rounded-lg shadow-lg hover:cursor-pointer hover:bg-blue-700 font-semibold text-white block mb-4" @click="onClickView">
      View Post
    </button>

    <button class="bg-blue-500 py-1 px-2 rounded-lg shadow-lg hover:cursor-pointer hover:bg-blue-700 font-semibold text-white block mb-4" @click="onClickNew">
      New Post
    </button>
  
    <div v-if="isNewPostFormShown" class="bg-blue-200 rounded-lg shadow-lg p-4">
      <div class="text-xl font-bold mb-4">
        New Blog Post
      </div>
      <Form />
    </div>

    <Post :post="post" class="mt-4" />
  </div>
</template>

<script setup lang="ts">
const postId = ref()
const post = ref()
const isNewPostFormShown = ref(false)

const onClickView = () => {
  $fetch(`/api/v1/Blog/Post?id=${postId.value}`, {
    server: false,
    onResponse({ response }) {
      if (!response.ok) {
        alert(response._data)
      } else {
        post.value = response._data
      }
    }
  })
}

const onClickNew = () => {
  isNewPostFormShown.value = !isNewPostFormShown.value
}
</script>

<style>
</style>