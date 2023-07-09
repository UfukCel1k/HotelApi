using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        //ilgili auto mapper kodları constructor(ctor) içerisine yazıyoruz.
        public AutoMapperConfig()
        {
            //RoomAddDto ile Room birleştiriyor.
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
        
            //Dto sınıfına geçmiş olduğumuz propertylerimizle entity katmanında yer alan sınıflarımızdaki propertylerimiz eşleşmiş olucak.
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
