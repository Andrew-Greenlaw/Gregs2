<template>
  <div class="home-page">
    {{ cars }}
  </div>
</template>

<script>
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getCars() {
      try {

      } catch (error) {
        Pop.error("[GetCars]", error)
      }
    }
    onMounted(() => {
      getCars()
    })
    return {
      cars: computed(() => AppState.cars)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
