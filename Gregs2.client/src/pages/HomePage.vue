<template>
  <div class="home-page row justify-content-center">
    <div class="col-12 d-flex justify-content-center p-3 bg-light">
      <!-- TODO searchbar -->
      -------------search bar--------------
    </div>
    <div class="col-3 mt-3 p-1">
      <div class="d-flex bg-light justify-content-center">
        cars
      </div>
      <div class="bg-secondary">
        search options
      </div>
    </div>
    <div class="col-3 mt-3 p-1">
      <div class="d-flex bg-light justify-content-center">
        jobs
      </div>
      <div class="bg-secondary">
        search options
      </div>
    </div>
    <div class="col-3 mt-3 p-1">
      <div class="d-flex bg-light justify-content-center">
        houses
      </div>
      <div class="bg-secondary">
        search options
      </div>
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
