<template>
    <div class="bg-blue-200 p-4 rounded-lg shadow-lg" v-if="post != undefined">
        <div class="text-2xl font-bold text-blue-500 mb-4">
            {{ post.title }}
        </div>
        {{ post.content }}
        <div class="flex justify-between mt-4">
            <div class="flex space-x-4">
                <div>
                    <button class="bg-blue-500 py-1 px-2 font-semibold text-white hover:cursor-pointer hover:bg-blue-700 rounded-lg">
                        Update
                    </button>
                </div>
                <div>
                    <button class="bg-blue-500 py-1 px-2 font-semibold text-white hover:cursor-pointer hover:bg-blue-700 rounded-lg">
                        Delete
                    </button>
                </div>
            </div>
            <div class="font-semibold italic">
                {{ post.name }}
                ({{ (new Date(post.createdAt)).toLocaleString() }})
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
const props = defineProps({
    post: {
        type: Object,
        required: true
    }
})
</script>