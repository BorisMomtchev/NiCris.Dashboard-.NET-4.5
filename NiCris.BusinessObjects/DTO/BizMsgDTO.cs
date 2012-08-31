using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiCris.BusinessObjects
{
    public class BizMsgDTO
    {
        // Required
        public string Name { get; set; }

        // Derived at Runtime
        public DateTime Date { get; set; }
        public string User { get; set; }

        // Optional
        public string Description { get; set; }
        public string AppId { get; set; }
        public string ServiceId { get; set; }
        public string StyleId { get; set; }
        public string Roles { get; set; }
    }
}
