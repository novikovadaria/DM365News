<template>
  <div class="news-card">
    <h3 class="news-title">{{ news.title }}</h3>
    <p class="news-summary">{{ news.summary }}</p>
  </div>
</template>

<script>
  export default {
    props: ['news'],
  };
</script>
