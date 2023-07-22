using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Bir tane client oluştur.
            var client = _httpClientFactory.CreateClient();
            //http://localhost:5030/api/About adresten istekte bulunuyoruz.
            var responseMessage = await client.GetAsync("http://localhost:5030/api/About");
            //Eğer istek yolladığımız adresten başarılı bir durum kodu dönerse gelen veriyi Jsondata ya atıyoruz. 
            //jsondaki veriyi deserilaze ederek listeledik.
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
