import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import NewsList from '../views/NewsList.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/news',
    name: 'News',
    component: NewsList
  }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

export default router;
