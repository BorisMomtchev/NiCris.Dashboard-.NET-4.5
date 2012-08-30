using NiCris.BusinessObjects;
using NiCris.CoreServices.Interfaces;
using NiCris.CoreServices.Services;
using NiCris.DataAccess.SQL.Repositories;
using NiCris.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NiCris.Web.Controllers
{
    public class BizServiceController : ApiController
    {
        IBizMsgCoreService _bizMsgCoreService;

        public BizServiceController()
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
        public HttpResponseMessage Post(BizMsg bizMsg)
        {
            // Save to db
            int id =_bizMsgCoreService.Insert(bizMsg);
            
            // Set the Http Location header
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/BizService/" + id.ToString());

            return response;
        }


        // PUT api/bizmsg/5
        //public void PutBizMsg(int id, BizMsg bizMsg)
        //{
        //}

        // DELETE api/bizmsg/5
        //public void DeleteBizMsg(int id)
        //{
        //}

    }
}
