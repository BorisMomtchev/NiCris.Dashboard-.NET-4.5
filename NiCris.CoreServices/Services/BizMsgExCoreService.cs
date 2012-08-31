using NiCris.CoreServices.Interfaces;
using NiCris.DataAccess.Interfaces;
using NiCris.DataAccess.SQL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NiCris.CoreServices.Services
{
    public class BizMsgExCoreService : IBizMsgExCoreService
    {
        // Fields & Properties
        IBizMsgExRepository BizMsgExRepository { get; set; }

        // C~tors
        public BizMsgExCoreService() : this(new BizMsgExRepository())
        {
        }

        public BizMsgExCoreService(IBizMsgExRepository bizMsgExRepository)
        {
            BizMsgExRepository = bizMsgExRepository;
        }


        #region ICRUDService<BizMsgEx> Members

        public IList<BusinessObjects.BizMsgEx> GetAll()
        {
            return BizMsgExRepository.GetAll().ToList();
        }

        public BusinessObjects.BizMsgEx GetById(int id)
        {
            return BizMsgExRepository.GetById(id);
        }

        public int Insert(BusinessObjects.BizMsgEx model)
        {
            return BizMsgExRepository.Insert(model);
        }

        public int Update(BusinessObjects.BizMsgEx model)
        {
            return BizMsgExRepository.Update(model);
        }

        public void Delete(BusinessObjects.BizMsgEx model)
        {
            BizMsgExRepository.Delete(model);
        }

        #endregion
    }
}
