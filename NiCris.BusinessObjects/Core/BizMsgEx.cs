using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NiCris.BusinessObjects
{
    public class BizMsgEx
    {
        // DB Id
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        // *** Required and Supplied by User
        [Required(ErrorMessage = "EntityName is required.")]
        public string EntityName { get; set; }

        // CRUD or a Custom Action
        [Required(ErrorMessage = "EntityAction is required.")]
        public string EntityAction { get; set; }


        // *** Derived at Runtime
        public string EntityValue { get; set; }

        [Required(ErrorMessage = "EntityType is required.")]
        public string EntityType { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "User is required.")]
        public string User { get; set; }


        // *** Optional
        public int? Serial { get; set; }
        public string Description { get; set; }

        // Lookups
        public int? AppId { get; set; }
        public int? ModuleId { get; set; }
        public int? ServiceId { get; set; }
        public int? StyleId { get; set; }

        public string Roles { get; set; }


        // *** Timestamp in db; used for opt. locking
        public string RowVersion { get; set; }
    }
}
