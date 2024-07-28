using AutoMapper;
using BookProduct.Models;
using BookProduct.ViewModel;

namespace BookProduct.Utils.AutoMapper
{
    public class OrganizationProfile:Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
