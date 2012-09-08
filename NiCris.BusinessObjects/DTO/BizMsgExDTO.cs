using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiCris.BusinessObjects
{
    public class BizMsgExDTO
    {
        // *** Required and Supplied by User
        public string EntityName { get; set; }
        public string EntityAction { get; set; }

        // *** Derived at Runtime
        public string EntityType { get; set; }
        public string EntityValue { get; set; }

        public string EntityStatus { get; set; }
        public string EntityErrorMessage { get; set; }
        public string EntityStackTrace { get; set; }

        public DateTime Date { get; set; }
        public string User { get; set; }


        // *** Optional
        public int? Serial { get; set; }
        public string Description { get; set; }

        public int? AppId { get; set; }
        public int? ModuleId { get; set; }
        public int? ServiceId { get; set; }
        public int? StyleId { get; set; }

        public string Roles { get; set; }
    }
}
