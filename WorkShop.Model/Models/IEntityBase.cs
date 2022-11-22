using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Model.Models
{
    public interface IEntityBase
    {
        public bool IsDeleted { set; get; }
        public long? DeletedBy { set; get; }
        public DateTime? DeletingDate { set; get; }
        public DateTime? CtreatingDate { set; get; }
        public long CreatorId { set; get; }
        public DateTime? ModifingDate { set; get; }
        public long? ModifierId { set; get; }
        
    }
}
