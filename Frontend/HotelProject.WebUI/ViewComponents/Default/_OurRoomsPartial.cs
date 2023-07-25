using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Bir tane client oluştur.
            var client = _httpClientFactory.CreateClient();
            //http://localhost:5030/api/Room adresten istekte bulunuyoruz.
            var responseMessage = await client.GetAsync("http://localhost:5030/api/Room");
            //Eğer istek yolladığımız adresten başarılı bir durum kodu dönerse gelen veriyi Jsondata ya atıyoruz. 
            //jsondaki veriyi deserilaze ederek listeledik.
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
