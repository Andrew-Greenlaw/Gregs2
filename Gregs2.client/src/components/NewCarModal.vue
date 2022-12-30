<template>
  <template>
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <form @submit.prevent="handleSubmit()">
          <div class="modal-header">
            <h5 class="modal-title">Create A Car Listing</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="mb-3">
              <input type="text" class="form-control" id="carMake" v-model="editable.make" placeholder="Name"
                maxlength="20" required aria-label="make input">
            </div>
            <div class="mb-3">
              <input type="text" class="form-control" id="carModel" v-model="editable.model" placeholder="Name"
                maxlength="20" required aria-label="model input">
            </div>
            <div class="mb-3">
              <textarea type="text" class="form-control" id="carDescription" v-model="editable.description"
                placeholder="Description" rows="3" required aria-label="Description Input" maxlength="100"></textarea>
            </div>
            <div class="mb-3">
              <label for="carImgUrl" class="form-label ps-2">Image</label>
              <input type="url" class="form-control" id="carImgUrl" v-model="editable.imgUrl"
                placeholder="https://Img.com.png">
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Close</button>
            <button type="submit" class="btn btn-primary" aria-label="Create">Create</button>
          </div>
        </form>
      </div>
    </div>
  </template>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { carsService } from '../services/CarsService.js';
import { AppState } from '../AppState.js';
import { AuthService } from '../services/AuthService.js';

export default {
  setup() {
    const editable = ref({})

    return {
      editable,
      async handleSubmit() {
        try {
          if (!AppState.account.id) {
            return AuthService.loginWithRedirect()
          }
          await carsService.createCar(editable.value)
        } catch (error) {
          Pop.error("[handle submit]", error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>