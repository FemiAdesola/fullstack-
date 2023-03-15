using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class CategoryDTO : BaseDTO<Category>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;

        public override void UpdateModel(Category model)
        {
            model.Name = Name;
            model.Image = Image;
        }
    }

    public class CategoryToReturnDTO : BaseReturnDTO<Category>
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public override void BaseToRetunModel(Category returnBase)
        {
            returnBase.Name = Name;
            returnBase.Image = Image;
        }
    }
}