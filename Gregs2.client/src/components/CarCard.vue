<template>
  <div class="cars-card col-md-4 elevation-2 mb-3 p-3 selectable">
    <div>
      <h3>{{ car.make }} | {{ car.model }}</h3>
      <img :src="car.imgUrl" alt="Car Image" class="car-img img-fluid">
    </div>
    <div class="car-text">
      <div>
        <h4>{{ car.year }}</h4>
        <h4>{{ car.price }}</h4>
      </div>
    </div>
    <div class="car-creator d-flex justify-content-between align-items-center w-100">
      <!-- routerlink might go here -->
      <p>contact?</p>
      <img :src="car.creator?.picture" alt="Creator Img" height="35" width="35">
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
.cars-card {
  background-color: lightgrey;
  transition: transform .3s;

  .car-image {
    object-fit: cover;
    object-position: center;
    height: 5rem;
    width: 5rem;
  }

  .car-text {
    text-overflow: ellipsis;
  }
}

.cars-card:hover {
  transform: scale(1.03);
}
</style>