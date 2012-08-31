using NiCris.BusinessObjects;
using NiCris.CoreServices.Interfaces;
using NiCris.CoreServices.Services;
using NiCris.DataAccess.SQL.Repositories;
using NiCris.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NiCris.Web.Controllers
{
    public class BizMsgServiceController : ApiController
    {
        IBizMsgCoreService _bizMsgCoreService;

        public BizMsgServiceController()
        {
            _bizMsgCoreService = new BizMsgCoreService(new BizMsgRepository());
        }

        // GET api/BizMsgService
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

        // POST api/BizMsgService
        public HttpResponseMessage Post(BizMsgDTO bizMsgDTO)
        {
            var bizMsg = new BizMsg();
            bizMsg.Name = bizMsgDTO.Name;
            bizMsg.Date = bizMsgDTO.Date;
            bizMsg.User = bizMsgDTO.User;

            // Save to db
            try { _bizMsgCoreService.Insert(bizMsg); }
            catch (ValidationException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
            // Set the Http Location header & return
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/BizMsgService/" + bizMsg.Id.ToString());
            return response;
        }


        // PUT api/BizMsgService/5
        public HttpResponseMessage Put(int id, BizMsgDTO bizMsgDTO)
        {
            var bizMsgToUpd = _bizMsgCoreService.GetById(id);
            if (bizMsgToUpd == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bizMsgToUpd.Name = bizMsgDTO.Name;
            bizMsgToUpd.Date = bizMsgDTO.Date;
            bizMsgToUpd.User = bizMsgDTO.User;

            // Save to db
            try { _bizMsgCoreService.Update(bizMsgToUpd); }
            catch (ValidationException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }

        // DELETE api/BizMsgService/5
        public HttpResponseMessage Delete(int id)
        {
            var bizMsgToDel = _bizMsgCoreService.GetById(id);
            if (bizMsgToDel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Delete in db
            _bizMsgCoreService.Delete(bizMsgToDel);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

    }
}
