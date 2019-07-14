using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HistoricalMysteryAPI.Contracts;
using HM.DataAccess.DB;
using HM.DataAccess.DB.Models;
using HM.Interfaces.IUtils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalMysteryAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly ILoggingService _log;

        public ArticlesController(IArticleRepository articleRepository, IMapper mapper, ILoggingService log)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _log = log;
        }

        [HttpGet]
        [Route("api/articles")]
        public async Task<ActionResult<IEnumerable<ArticleItem>>> GetAllArticles()
        {
            IEnumerable<ArticleItemDto> articleItemDtos = await _articleRepository.GetAllArticles();
            IEnumerable<ArticleItem> articleItems = _mapper.Map<IEnumerable<ArticleItem>>(articleItemDtos);
            return Ok(articleItems);
        }

        [HttpGet]
        [Route("api/articles/{articleId}")]
        public async Task<ActionResult<ArticleItem>> GetArticleById([FromRoute] int articleId)
        {
            ArticleItemDto articleItemDto = await _articleRepository.GetArticleById(articleId);
            ArticleItem articleItem = _mapper.Map<ArticleItem>(articleItemDto);
            return Ok(articleItem);
        }

        [HttpGet]
        [Route("api/articles/heroArticles")]
        public async Task<ActionResult<IEnumerable<ArticleItem>>> GetHeroArticles()
        {
            IEnumerable<ArticleItemDto> articleItemDtos = await _articleRepository.GetHeroArticle();
            IEnumerable<ArticleItem> articleItems = _mapper.Map<IEnumerable<ArticleItem>>(articleItemDtos);
            return Ok(articleItems);
        }

        [HttpGet]
        [Route("api/articles/featureArticles")]
        public async Task<ActionResult<IEnumerable<ArticleItem>>> GetFeatureArticles()
        {
            IEnumerable<ArticleItemDto> articleItemDtos = await _articleRepository.GetFeatureArticle();
            IEnumerable<ArticleItem> articleItems = _mapper.Map<IEnumerable<ArticleItem>>(articleItemDtos);
            return Ok(articleItems);
        }

        [HttpGet]
        [Route("api/articles/articleContent/{articleId}")]
        public async Task<ActionResult<IEnumerable<ArticleContent>>> GetArticleContent([FromRoute] int articleId)
        {
            IEnumerable<ArticleContentDto> articleItemDtos = await _articleRepository.GetArticleContent(articleId);
            IEnumerable<ArticleContent> articleItems = _mapper.Map<IEnumerable<ArticleContent>>(articleItemDtos);
            return Ok(articleItems);
        }

        [HttpPost]
        [Route("api/articles/newArticle")]
        public async Task<ActionResult<int>> GetArticleContent([FromBody] NewArticleRequest articleRequest)
        {

            int articleId = await _articleRepository.SaveArticleRecord(
                articleRequest.ArticleAuthorId,
                articleRequest.ArticleFeatureImage,
                articleRequest.ArticleDisplayTitle,
                articleRequest.ArticleDisplaySubtitle,
                _mapper.Map<NewArticleContentRequest[], ArticleContentRequest[]>(articleRequest.ArticleContent)
                );

            return Ok(articleId);
        }
    }
}