<template>
  <div class="cars-card col-md-4">
    <div class="shadow car-image" :style="{ backgroundImage: `url(${car.imgUrl})` }">
    </div>
    <div class="shadow car-text mt-3 bg-secondary p-2 text-center">
      <h3>{{ car.make }} {{ car.model }}</h3>
      <div class="d-flex justify-content-around ">
        <h5>{{ car.price }}</h5>
        <span>|</span>
        <h5>{{ car.year }}</h5>
      </div>
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
  transition: transform .3s;

  .car-image {
    background-size: cover;
    object-fit: cover;
    background-position: center;
    width: 100%;
    padding-top: 100%;
    position: relative;
  }

  .car-text {
    text-overflow: ellipsis;
  }
}

.cars-card:hover {
  transform: scale(1.03);
}
</style>