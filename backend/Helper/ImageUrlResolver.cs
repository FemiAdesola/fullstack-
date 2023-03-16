using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Helper
{
    public class ImageUrlResolver : IValueResolver<Product, ProductToReturnDTO,string>
    {
        private readonly IConfiguration _config;
        public ImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, 
        string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Images))
            {
                return _config["ApiUrl"] + source.Images;
            }
            return null;
        }
    }
}