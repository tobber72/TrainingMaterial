using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

namespace WebApi.DataService.App_Code
{
    /// <summary>
    /// Mappers contains sample code for using AutoMapper to map objects.
    /// </summary>
    public class Mappers
    {

        //#region "Sample Mapping"
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public Entity_DTO Entity(Entity obj)
        //{
        //    Mapper.CreateMap<Entity, Entity_DTO>();
        //    Entity_DTO details = Mapper.Map<Entity, Entity_DTO>(obj);
        //    return details;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public List<Entity_DTO> Entity(List<Entity> obj)
        //{
        //    Mapper.CreateMap<Entity, Entity_DTO>();
        //    IList<Entity_DTO> details = Mapper.Map<IList<Entity>, IList<Entity_DTO>>(obj);
        //    return details.ToList();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public Entity Entity(Entity_DTO obj)
        //{
        //    Mapper.CreateMap<Entity_DTO, Entity>()
        //        .ForMember(dest => dest.Links, opt => opt.MapFrom(src =>
        //                            new List<Link>
        //                               {
        //                                   new Link
        //                                       {
        //                                           Title = "self",
        //                                           Rel = "self",
        //                                           Href = "/api/Entity/" + src.Id
        //                                       },
        //                                   new Link
        //                                       {
        //                                           Title = "All Entity",
        //                                           Rel = "all",
        //                                           Href = "/api/Entity"
        //                                       }
        //                               }));


        //    Entity details = Mapper.Map<Entity_DTO, Entity>(obj);
        //    return details;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public List<Entity> Entity(List<Entity_DTO> obj)
        //{
        //    Mapper.CreateMap<Entity_DTO, Entity>()
        //                      .ForMember(dest => dest.Links, opt => opt.MapFrom(src =>
        //                            new List<Link>
        //                               {
        //                                   new Link
        //                                       {
        //                                           Title = "self",
        //                                           Rel = "self",
        //                                           Href = "/api/Entity/" + src.Id
        //                                       },
        //                                   new Link
        //                                       {
        //                                           Title = "All Entity",
        //                                           Rel = "all",
        //                                           Href = "/api/Entity"
        //                                       }
        //                               }));

        //    IList<Entity> details = Mapper.Map<IList<Entity_DTO>, IList<Entity>>(obj);
        //    return details.ToList();
        //}

        //#endregion

    }
}