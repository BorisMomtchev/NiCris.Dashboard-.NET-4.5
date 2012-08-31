using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NiCris.Web.Models
{
    [CollectionDataContract(Namespace = "", Name = "BizMsgExList")]
    public class BizMsgExList : List<NiCris.BusinessObjects.BizMsgEx>
    {
    }
}