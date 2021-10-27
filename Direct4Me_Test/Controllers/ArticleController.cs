using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Direct4Me_Test.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Direct4Me_Test.Services;
using Direct4Me_Test.Entities;
using Direct4Me_Test.Models.Articles;
using Direct4Me_Test.Models.Users;

namespace Direct4Me_Test.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ArticlesController(
            IArticleService articleService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _articleService = articleService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var articles = _articleService.GetAll();
            var model = _mapper.Map<IList<ArticleModel>>(articles);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var article = _articleService.GetById(id);
            var model = _mapper.Map<ArticleModel>(article);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] SaveArticleModel model)
        {
            // map model to entity
            var articel = _mapper.Map<Article>(model);

            try
            {
                // create user
                _articleService.Create(articel);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterWithCode([FromBody] SaveWithCodeMode model)
        {
            // map model to entity
            var articel = _mapper.Map<Article>(model);

            try
            {
                // create user
                _articleService.RegisterWithCode(articel);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateArticleModel model)
        {
            // map model to entity and set id
            var article = _mapper.Map<Article>(model);
            article.Id = id;

            try
            {
                // update Article 
                _articleService.Update(article);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return Ok();
        }

        // Delivery Service


    }
}
