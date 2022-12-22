<template>
  <div class="jobs-page">
    {{ jobs }}
  </div>
</template>


<script>
import { onMounted } from 'vue';
import { jobsService } from '../services/JobsService.js'
import Pop from '../utils/Pop.js';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getJobs() {
      try {
        await jobsService.getJobs()
      } catch (error) {
        Pop.error("[getJobs]", error)
      }
    }
    onMounted(() => {
      getJobs()
    })
    return {
      jobs: computed(() => { AppState.jobs })
    }
  }
}
</script>


<style lang="scss" scoped>

</style>