<template>
    <div class="bg-blue-200 p-4 rounded-lg shadow-lg" v-if="post != undefined">
        <div class="text-2xl font-bold text-blue-500 mb-4">
            {{ post.title }}
        </div>
        {{ post.content }}
        <div class="flex justify-between mt-4">
            <div class="flex space-x-4">
                <div>
                    <button class="bg-blue-500 py-1 px-2 font-semibold text-white hover:cursor-pointer hover:bg-blue-700 rounded-lg" @click="onClickUpdate">
                        Update
                    </button>
                </div>
                <div>
                    <button class="bg-blue-500 py-1 px-2 font-semibold text-white hover:cursor-pointer hover:bg-blue-700 rounded-lg" @click="onClickDelete">
                        Delete
                    </button>
                </div>
            </div>
            <div class="font-semibold italic">
                {{ post.name }}
                ({{ (new Date(post.createdAt)).toLocaleString() }})
                <div v-if="post.updatedAt != undefined">
                    Updated: {{ (new Date(post.updatedAt)).toLocaleString() }}
                </div>
            </div>
        </div>
        <Form v-if="isFormShown" class="mt-4" :post="post" />
    </div>
</template>

<script setup lang="ts">
const props = defineProps({
    post: {
        type: Object,
        required: true
    }
})

const emit = defineEmits(['delete'])
const isFormShown = ref(false)

const onClickUpdate = () => {
    isFormShown.value = !isFormShown.value
}

const onClickDelete = () => {
    $fetch(`/api/v1/Blog/Post?id=${props.post.id}`, {
        server: false,
        method: 'DELETE',
        onResponse({ response }) {
            if (!response.ok) {
                alert(`Could not delete blog post #${props.post.id}.`)
            } else {
                emit('delete')
            }
        }
    })
}
</script>