using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServicePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Bir tane client oluştur.
            var client = _httpClientFactory.CreateClient();
            //http://localhost:5030/api/Room adresten istekte bulunuyoruz.
            var responseMessage = await client.GetAsync("http://localhost:5030/api/Service");
            //Eğer istek yolladığımız adresten başarılı bir durum kodu dönerse gelen veriyi Jsondata ya atıyoruz. 
            //jsondaki veriyi deserilaze ederek listeledik.
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
