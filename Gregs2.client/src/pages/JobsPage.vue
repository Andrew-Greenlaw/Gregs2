<template>
  <div class="component">


  </div>
</template>


<script>
import { onMounted } from 'vue';
import { jobsService } from '../services/JobsService.js'
import Pop from '../utils/Pop.js';

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
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>