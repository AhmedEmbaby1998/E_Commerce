using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Model.Models.Products
{
    public class Product: IEntityBase
    {
        public long Id { get; set; }
        [ConcurrencyCheck]
        public long Version { set; get; }
        public string NameEn { get; set; }
        public string NameAr { set; get; }
        public int CategoryId { set; get; }
        public ProductCategory Category { set; get; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { set; get; }
        public double CurrentPrice { set; get; }
        public bool HasAvailableStock { set; get; }
        public bool  IsDeleted { set; get; }
        public long? DeletedBy { set; get; }
        public DateTime? DeletingDate { set; get; }
        public DateTime? CtreatingDate { set; get; }
        public long CreatorId { set; get; }
        public DateTime? ModifingDate { set; get; }
        public long? ModifierId { set; get; }

    }
}
