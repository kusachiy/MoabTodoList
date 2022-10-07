<template>
  <v-app>
    <v-app-bar app color="green" dark>
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="./assets/logo.png"
          transition="scale-transition"
          width="40"
        />
        <h3>TODO List</h3>
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/kusachiy/AdsProTest"
        target="_blank"
        text
      >
        <span class="mr-2">App Source</span>
        <v-icon>mdi-github</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <TodoList />
    </v-main>
  </v-app>
</template>

<script>
import TodoList from "./components/TodoList";

export default {
  name: "App",

  components: {
    TodoList,
  },

  data: () => ({
    //
  }),
};
</script>
