<template>
  <header>
    <Navbar />
  </header>
  <main class="d-flex">
    <div class="container-fluid">
      <div class="row main">
        <div class="col-md-2 bg-secondary">
          <div>My Favorites</div>
          <div>Create Listing</div>
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
