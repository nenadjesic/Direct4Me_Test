using System;
using System.Collections.Generic;
using System.Linq;
using Direct4Me_Test.Entities;
using Direct4Me_Test.Helpers;
using Direct4Me_Test.Models.Articles;

namespace Direct4Me_Test.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        Article Create(Article article);

        Article RegisterWithCode(Article article);
        void Update(Article article);
        void Delete(int id);
    }

    public class ArticleService : IArticleService
    {
        private DataContext _context;

        public ArticleService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }

        public Article GetById(int id)
        {
            return _context.Articles.Find(id);
        }

        public Article Create(Article article)
        {

            if (string.IsNullOrWhiteSpace(article.ExternalId))
                throw new AppException("ExternalId is required");

            if (string.IsNullOrWhiteSpace(article.Title))
                throw new AppException("Title is required");

            if (string.IsNullOrWhiteSpace(article.Summary))
                throw new AppException("Summary is required");

            var deliveryCode = article.ExternalId.Substring(0, 4) == "1696" ? article.ExternalId.Substring(0, 4) : article.ExternalId.Substring(0, 2);

            var delivery = _context.DeliveryServices.Where(x => x.Code == deliveryCode).FirstOrDefault();

            if (_context.Articles.Any(x => x.ExternalId == article.ExternalId))
                throw new AppException("Article with  \"" + article.ExternalId + "\" exist in system");

            article.DeliveryService = delivery;

            _context.Articles.Add(article);
            _context.SaveChanges();

            return article;
        }

        public Article RegisterWithCode(Article article)
        {

            if (string.IsNullOrWhiteSpace(article.ExternalId))
                throw new AppException("ExternalId is required");

            if (string.IsNullOrWhiteSpace(article.ExternalId))
                throw new AppException("ExternalId is required");

            var deliveryCode = article.ExternalId.Substring(0, 4) == "1696" ? article.ExternalId.Substring(0, 4) : article.ExternalId.Substring(0, 2);

            var delivery = _context.DeliveryServices.Where(x => x.Code == deliveryCode).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(delivery.Title))
                throw new AppException("Delivery is not in system");

            if (_context.Articles.Any(x => x.ExternalId == article.ExternalId))
                throw new AppException("Article with  \"" + article.ExternalId + "\" exist in system");

            article.Title = "Articel delivery with " + delivery.Title + " " + article.ExternalId;
            article.DeliveryService = delivery;

            _context.Articles.Add(article);
            _context.SaveChanges();

            return article;
        }


        public void Update(Article articleParam)
        {
            var article = _context.Articles.Find(articleParam.Id);

            if (article == null)
                throw new AppException("Article not found");

            if (string.IsNullOrWhiteSpace(article.Title))
                throw new AppException("Title is required");

            if (string.IsNullOrWhiteSpace(article.Summary))
                throw new AppException("Summary is required");

            if (string.IsNullOrWhiteSpace(article.DeliveryService.Title))
                throw new AppException("DeliveryService is required");

            article.Title = articleParam.Title;
            article.Summary = articleParam.Summary;
            article.Author = articleParam.Author;
            article.ExternalId = articleParam.ExternalId;
            article.DeliveryService = articleParam.DeliveryService;
           

            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}