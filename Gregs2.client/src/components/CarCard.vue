<template>
  <div class="cars-card col-md-4">
    <div>
      <img :src="car.imgUrl" alt="Car Image" class="img-fluid">
    </div>
    <div class="car-text">
      <div>
        <h3>{{ car.make }}|{{ car.model }}</h3>
        <h4>{{ car.year }}</h4>
        <h4>{{ car.price }}</h4>
      </div>
    </div>
    <div class="car-creator">
      <!-- routerlink might go here -->
      <p>contact?</p>
      <img :src="car.creator?.picture" alt="Creator Img">
    </div>
    <div v-if="car.isSold">
      <h3>SOLD</h3>
    </div>
  </div>
</template>


<script>
import { Car } from '../models/Car.js';

export default {
  props: {
    car: {
      type: Car,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>