using AutoMapper;
using DTOLayer.DTOs.AnnouncementDto;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        protected MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();
        }
    }
}
