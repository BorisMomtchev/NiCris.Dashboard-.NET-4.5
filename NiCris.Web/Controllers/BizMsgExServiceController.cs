using NiCris.BusinessObjects;
using NiCris.CoreServices.Interfaces;
using NiCris.CoreServices.Services;
using NiCris.DataAccess.SQL.Repositories;
using NiCris.Web.Hubs;
using NiCris.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NiCris.Web.Controllers
{
    public class BizMsgExServiceController : ApiController
    {
         IBizMsgExCoreService _bizMsgExCoreService;

        public BizMsgExServiceController()
        {
            _bizMsgExCoreService = new BizMsgExCoreService(new BizMsgExRepository());
        }

        // GET api/BizMsgExService
        public BizMsgExList Get()
        {
            var bizMsgExList = new BizMsgExList();
            bizMsgExList.AddRange(_bizMsgExCoreService.GetAll());
            return bizMsgExList;
        }

        // GET api/BizMsgExService/5
        public BizMsgEx Get(int id)
        {
            BizMsgEx bizMsgEx = _bizMsgExCoreService.GetById(id);
            return bizMsgEx;
        }

        // POST api/BizMsgExService
        public HttpResponseMessage Post(BizMsgExDTO bizMsgExDTO)
        {
            var bizMsgEx = new BizMsgEx();

            bizMsgEx.EntityName = bizMsgExDTO.EntityName;
            bizMsgEx.EntityAction = bizMsgExDTO.EntityAction;

            bizMsgEx.EntityValue = bizMsgExDTO.EntityValue;
            bizMsgEx.EntityType = bizMsgExDTO.EntityType;

            bizMsgEx.Date = bizMsgExDTO.Date;
            bizMsgEx.User = bizMsgExDTO.User;

            // Save to db
            try { _bizMsgExCoreService.Insert(bizMsgEx); }
            catch (ValidationException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
            // Set the Http Location header & return
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/BizMsgExService/" + bizMsgEx.Id.ToString());

            // Inform all connected Clients via our Notifier
            Notifier.Send(bizMsgEx);

            return response;
        }


        // PUT api/BizMsgService/5
        public HttpResponseMessage Put(int id, BizMsgExDTO bizMsgExDTO)
        {
            var bizMsgExToUpd = _bizMsgExCoreService.GetById(id);
            if (bizMsgExToUpd == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bizMsgExToUpd.EntityName = bizMsgExDTO.EntityName;
            bizMsgExToUpd.EntityAction = bizMsgExDTO.EntityAction;

            bizMsgExToUpd.EntityValue = bizMsgExDTO.EntityValue;
            bizMsgExToUpd.EntityType = bizMsgExDTO.EntityType;

            bizMsgExToUpd.Date = bizMsgExDTO.Date;
            bizMsgExToUpd.User = bizMsgExDTO.User;

            // Save to db
            try { _bizMsgExCoreService.Update(bizMsgExToUpd); }
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
            var bizMsgExToDel = _bizMsgExCoreService.GetById(id);
            if (bizMsgExToDel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Delete in db
            _bizMsgExCoreService.Delete(bizMsgExToDel);

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }
    }
}
