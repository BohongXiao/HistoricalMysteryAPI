using System.Threading.Tasks;
using HM.DataAccess.DB;
using HM.Interfaces.IUtils;
using HM.Models;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalMysteryAPI.Controllers
{
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ILoggingService _log;

        public ArticlesController(IArticleRepository articleRepository, ILoggingService log)
        {
            _articleRepository = articleRepository;
            _log = log;
        }

        [HttpGet]
        [Route("api/articles")]
        public async Task<ActionResult<ArticleItem[]>> GetAllArticles()
        {
            var result =await _articleRepository.GetAllArticles();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/articles/{:id}")]
        public async Task<ActionResult<ArticleItem[]>> GetArticleById([FromRoute] int id)
        {
            var result = await _articleRepository.GetArticleById(id);
            return Ok(result);
        }
    }
}