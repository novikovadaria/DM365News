// defined in .env
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const fetchNews = async (query = '') => {
  let url = API_BASE_URL;

  if (query) {
    url = `${API_BASE_URL}/search?query=${encodeURIComponent(query)}`;
  }

  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error('Failed to fetch news');
    }
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error loading news:', error);
    throw error;
  }
};

// Fetch news by ID
