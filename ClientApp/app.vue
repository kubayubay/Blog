<template>
  <div>
    <NuxtRouteAnnouncer />
    <!-- <NuxtWelcome /> -->
    {{ post }}
    <Post />
  </div>
</template>

<script setup lang="ts">
const url = '/api/v1/Blog'
const post = ref()

onMounted(() => {
  $fetch(`${url}/Post`, {
    server: false,
    onResponse({ response }) {
      post.value = response._data
    }
  })
})
</script>

<style>
</style>