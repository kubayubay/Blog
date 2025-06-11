<template>
    <div>
        <h1>
            My Blog
        </h1>
        <p>
            {{ post }}
        </p>
    </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'

const post = ref()

onMounted(async () => {
    const response = await fetch('https://localhost:5002/api/v1/Blog/Post')
    post.value = await response.text()
})
</script>

<style>
</style>