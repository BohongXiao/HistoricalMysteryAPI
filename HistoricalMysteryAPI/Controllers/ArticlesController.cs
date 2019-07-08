using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HistoricalMysteryAPI.Contracts;
using HM.DataAccess.DB;
using HM.DataAccess.DB.Models;
using HM.Interfaces.IUtils;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalMysteryAPI.Controllers
{
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
        [Route("api/articles/{id}")]
        public async Task<ActionResult<ArticleItem>> GetArticleById([FromRoute] int id)
        {
            ArticleItemDto result = await _articleRepository.GetArticleById(id);
            return Ok(result);
        }
    }
}