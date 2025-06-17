<template>
    <div v-if="post != undefined">
        <label>Type in a title:</label>
        <input type="text" v-model="post.title" name="title" class="border ml-4 rounded w-1/2" />

        <div>
            <label class="block">Type in your blog post:</label>
            <textarea v-model="post.content" class="border w-full h-32 rounded" />
        </div>

        <button class="bg-blue-500 py-1 px-2 hover:cursor-pointer hover:bg-blue-700 rounded-lg shadow-lg font-semibold text-white mt-4" @click="onClickSubmit">
            <span v-if="post != undefined && post.id != 0">
                Update Blog Post
            </span>
            <span v-else>
                Create Blog Post
            </span>
        </button>
    </div>
</template>

<script setup lang="ts">
const props = defineProps({
    post: {
        type: Object,
        required: false
    }
})

const post = ref()

if (props.post != undefined) {
    post.value = props.post
} else {
    post.value = {
        id: 0,
        title: '',
        content: ''
    }
}

const onClickSubmit = () => {
    if (props.post != undefined && props.post.id != 0) {
        // Update the blog post (PUT)
        $fetch('/api/v1/Blog/Post', {
            server: false,
            method: 'PUT',
            body: props.post,
            onResponse({ response }) {
                if (!response.ok) {
                    alert(response._data)
                } else {
                    alert(`Blog post #${props.post.id} was updated!`)
                }

                post.value = undefined
            }
        })
    } else {
        // Create a new blog post (POST)
        $fetch('/api/v1/Blog/Post', {
            server: false,
            method: 'POST',
            body: post.value,
            onResponse({ response }) {
                if (!response.ok) {
                    alert('Error: ' + response._data)
                } else {
                    alert(`Blog post #${response._data.id} was created!`)
                }
            }
        })
    }
}
</script>