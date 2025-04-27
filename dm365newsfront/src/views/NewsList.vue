<template>
  <div>
    <div class="header-container">
      <h1>Daily News</h1>
      <input type="text"
             v-model="searchQuery"
             @keyup.enter="searchNews"
             placeholder="Enter text to search "
             class="search-input" />
    </div>

    <div v-if="loading">Loading...</div>
    <div v-else>
      <news-card v-for="(newsItem, index) in newsList"
                 :key="index"
                 :news="newsItem" />
    </div>
  </div>
</template>

<script>

  import { fetchNews } from '../services/newsService';
  import NewsCard from '../components/NewsCard.vue';

  export default {
    components: {
      NewsCard
    },
    data() {
      return {
        newsList: [], 
        loading: true, 
        searchQuery: '', 
      };
    },
    mounted() {

      // loading all news when the component is mounted
      this.loadNews();
    },
    methods: {
      async loadNews(query = '') {
        this.loading = true;
        try {
          const data = await fetchNews(query); 
          this.newsList = data; 
        } catch (error) {
          console.error('Error loading news:', error);
        } finally {
          this.loading = false; 
        }
      },

      // handle search input
      searchNews() {
        this.loadNews(this.searchQuery);
      }
    }
  };
</script>
