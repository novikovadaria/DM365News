using DM365News.Interfaces;
using DM365News.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DM365News.Services
{
    /// <summary>
    /// Service for managing news data.
    /// </summary>
    public class NewsService : INewsService
    {
        private readonly List<NewsItem> _news;
        private readonly ILogger<NewsService> _logger;

        /// <summary>
        /// Constructor of the NewsService. Loads data from a JSON file.
        /// </summary>
        /// <param name="logger">The logger instance used for logging errors and information.</param>
        public NewsService(ILogger<NewsService> logger)
        {
            _logger = logger;

            try
            {
                var json = File.ReadAllText("Data/news.json");
                _news = JsonSerializer.Deserialize<List<NewsItem>>(json) ?? new List<NewsItem>();

                if (_news.Count == 0)
                {
                    throw new InvalidOperationException("No news items found in the JSON file.");
                }

                _logger.LogInformation($"{_news.Count} news items loaded successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading the news data.");
                throw new Exception("An error occurred while loading the news data.", ex);
            }
        }

        /// <summary>
        /// Gets all news items.
        /// </summary>
        /// <returns>An IEnumerable of all news items.</returns>
        public IEnumerable<NewsItem> GetAll()
        {
            return _news;
        }

        /// <summary>
        /// Searches for news items based on a query string.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>An IEnumerable of news items that match the search query.</returns>
        /// <exception cref="ArgumentException">Thrown when the search query is null or empty.</exception>
        public IEnumerable<NewsItem> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Search query cannot be null or empty.", nameof(query));
            }

            _logger.LogInformation($"Searching for news with query: {query}");
            var result = _news.Where(n =>
                n.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                n.Summary.Contains(query, StringComparison.OrdinalIgnoreCase));

            _logger.LogInformation($"Found {result.Count()} news items matching the query.");
            return result;
        }
    }
}
