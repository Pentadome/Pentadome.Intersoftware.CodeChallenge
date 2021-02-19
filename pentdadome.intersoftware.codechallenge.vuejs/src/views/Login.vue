
<template>
  <div class="about">
    <button @click="login">Login</button>
  </div>
</template>

<script lang="ts">

import { Options, Vue } from 'vue-class-component'
import { store } from '@/store'

export default class Login extends Vue {
  login () {
    store.commit('setAdmin', true)
    this.$router.push('/')
  }
}
</script>
