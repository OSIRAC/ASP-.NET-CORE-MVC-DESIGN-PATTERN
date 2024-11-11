using AutoMapper;
using EFCORE_VERİALMA.Models;
using EFCORE_VERİALMA.Models.ViewModels;

namespace EFCORE_VERİALMA.Mapping
{
    public class ViewModelMapping :Profile
    {
        public ViewModelMapping()
        {         
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();
        }

    }
}
