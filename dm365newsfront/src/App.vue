<template>
  <div class="app-container">
    <h1 class="app-title">DM365 News App</h1>
    <nav class="navigation">
      <router-link to="/" class="nav-link">Home</router-link> |
      <router-link to="/news" class="nav-link">News</router-link>
    </nav>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: 'App'
  };
</script>
