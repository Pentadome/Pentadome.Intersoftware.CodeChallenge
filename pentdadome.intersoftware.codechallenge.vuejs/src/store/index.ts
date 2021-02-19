import { createStore } from 'vuex'

export const store = createStore({
  state: {
    isAdmin: false
  },
  mutations: {
    setAdmin (state, isAdmin) {
      state.isAdmin = isAdmin
    }
  },
  actions: {
  },
  modules: {
  }
})
