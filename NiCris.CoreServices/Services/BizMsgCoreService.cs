using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NiCris.CoreServices.Interfaces;
using NiCris.DataAccess.Interfaces;
using NiCris.DataAccess.SQL.Repositories;

namespace NiCris.CoreServices.Services
{
    public class BizMsgCoreService : IBizMsgCoreService
    {
        // Fields & Properties
        IBizMsgRepository BizMsgRepository { get; set; }

        // C~tors
        public BizMsgCoreService() : this(new BizMsgRepository())
        {
        }

        public BizMsgCoreService(IBizMsgRepository businessMsgRepository)
        {
            BizMsgRepository = businessMsgRepository;
        }

        #region ICRUDService<BizMsg> Members

        public IList<BusinessObjects.BizMsg> GetAll()
        {
            return BizMsgRepository.GetAll().ToList();
        }

        public BusinessObjects.BizMsg GetById(int id)
        {
            return BizMsgRepository.GetById(id);
        }

        public int Insert(BusinessObjects.BizMsg model)
        {
            return BizMsgRepository.Insert(model);
        }

        public int Update(BusinessObjects.BizMsg model)
        {
            return BizMsgRepository.Update(model);
        }

        public void Delete(BusinessObjects.BizMsg model)
        {
            BizMsgRepository.Delete(model);
        }

        #endregion
    }
}
