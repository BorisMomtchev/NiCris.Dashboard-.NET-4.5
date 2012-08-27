using NiCris.BusinessObjects;
using NiCris.CoreServices.Interfaces;
using NiCris.CoreServices.Services;
using NiCris.DataAccess.SQL.Repositories;
using NiCris.Web.Models;
using System.Web.Http;

namespace NiCris.Web.Controllers
{
    public class BizMsgController : ApiController
    {
        IBizMsgCoreService _bizMsgCoreService;

        public BizMsgController()
        {
            _bizMsgCoreService = new BizMsgCoreService(new BizMsgRepository());
        }

        // GET api/bizmsg
        public BizMsgList Get()
        {
            BizMsgList bizMsgList = new BizMsgList();
            bizMsgList.AddRange(_bizMsgCoreService.GetAll());
            return bizMsgList;
        }

        // GET api/bizmsg/5
        public BizMsg Get(int id)
        {
            BizMsg bizMsg = _bizMsgCoreService.GetById(id);
            return bizMsg;
        }

        // POST api/bizmsg
        public BizMsg Post(BizMsgDTO bizMsgDTO)
        {
            var bizMsg = new BizMsg();
            bizMsg.Name = bizMsgDTO.Name;
            bizMsg.Date = bizMsgDTO.Date;
            bizMsg.User = bizMsgDTO.User;

            // Save to db
            int id =_bizMsgCoreService.Insert(bizMsg);
            
            // TODO: Set the Http Location header

            // Return the full object for now...
            return bizMsg;
        }


        // PUT api/bizmsg/5
        public void Put(int id, BizMsgDTO bizMsgDTO)
        {
        }

        // DELETE api/bizmsg/5
        public void Delete(int id)
        {
        }

    }
}
