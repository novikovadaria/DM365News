using DM365News.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DM365News.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        /// <summary>
        /// Get all news.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var news = _newsService.GetAll();

                if (news is null || news.Count() == 0)
                {
                    _logger.LogInformation("No news available to display.");
                    return NoContent();
                }

                return Ok(news); 
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "Error while fetching all news.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Search news based on the query.
        /// </summary>
        /// <param name="query">Search query string.</param>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return BadRequest("Query cannot be empty.");
                }

                _logger.LogInformation($"Searching for news with query: {query}");
                var result = _newsService.Search(query);

                if (result == null || result.Count() == 0)
                {
                    _logger.LogInformation("No news found for the given search query.");
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while searching for news.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
