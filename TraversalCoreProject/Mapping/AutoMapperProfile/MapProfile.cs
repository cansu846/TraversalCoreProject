﻿using AutoMapper;
using DTOLayer.DTOs.AnnouncementDto;
using DTOLayer.DTOs.ContactDto;
using EntityLayer.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<ContactSideUserMessage, SendMessageDto>().ReverseMap();

        }
    }
}
