<template>
  <header>
    <Navbar />
  </header>
  <main class="d-flex">
    <div class="container-fluid">
      <div class="row main">
        <div class="col-md-2 bg-secondary">
          <div class="dropdown mb-2">
            <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
              aria-expanded="false">
              Create Listing
            </button>
            <ul class="dropdown-menu">
              <li><a class="dropdown-item" href="#">Car</a></li>
              <li><a class="dropdown-item" href="#">Job</a></li>
              <li><a class="dropdown-item" href="#">House</a></li>
            </ul>
          </div>
          <div class="dropdown">
            <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
              aria-expanded="false">
              Favorites
            </button>
            <ul class="dropdown-menu">
              <li><a class="dropdown-item" href="#">All</a></li>
              <li><a class="dropdown-item" href="#">Cars</a></li>
              <li><a class="dropdown-item" href="#">Jobs</a></li>
              <li><a class="dropdown-item" href="#">Houses</a></li>
            </ul>
          </div>
        </div>
        <div class="col-md-10">
          <router-view />

        </div>
      </div>
    </div>
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.main {
  height: 100%;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
