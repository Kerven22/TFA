using AutoMapper;
using TFA.Domain.Models;
using TFA.Storage.Models;

namespace TFA.Storage.Mapping
{
    public class StorageProfile:Profile
    {
        public StorageProfile()
        {
            CreateMap<Topic, TopicDto>()
                .ForMember(d => d.Id, s => s.MapFrom(t => t.TopicId));
            CreateMap<Forum, ForumDto>()
                .ForMember(d=>d.Id, s=>s.MapFrom(t => t.ForumId));
        }
    }
}
