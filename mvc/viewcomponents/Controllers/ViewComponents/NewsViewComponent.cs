using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ViewComponents
{
    public class NewsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var news = await GetNews();

            return View(news);
        }

        private Task<List<News>> GetNews()
        {
            var news = new List<News>()
            {
                new News() { Id = 1, Title = "News 1"},
                new News() { Id = 2, Title = "News 2"}
            };

            return Task.FromResult(news);
        }
    }
}