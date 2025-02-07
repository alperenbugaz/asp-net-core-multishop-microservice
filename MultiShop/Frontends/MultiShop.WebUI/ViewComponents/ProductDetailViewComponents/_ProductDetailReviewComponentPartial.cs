using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        IHttpClientFactory _clientFactory;
        public _ProductDetailReviewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {   
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7194/api/Comment/CommentsListByProductId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);
                return View(values);
            }
            return View();
        }
    }
}
