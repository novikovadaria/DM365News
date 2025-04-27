using DM365News.Models;

namespace DM365News.Interfaces
{
    public interface INewsService
    {
        /// <summary>
        /// Retrieves all news items.
        /// </summary>
        /// <returns>A collection of all news items.</returns>
        IEnumerable<NewsItem> GetAll();

        /// <summary>
        /// Searches for news items that match the provided query.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>A collection of news items that match the search query.</returns>
        IEnumerable<NewsItem> Search(string query);
    }
}
