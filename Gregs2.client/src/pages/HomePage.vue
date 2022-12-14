<template>
  <div class="home-page container-fluid">
    <div class="row">
      <CarCard v-for="c in cars" :car="c" :key="c.id" />
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { onMounted } from 'vue';
import { carsService } from '../services/CarsService.js'
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getCars() {
      try {
        await carsService.getCars()
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
