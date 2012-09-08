using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiCris.DataAccess.SQL.Mappers
{
    public class BizMsgExMapper
    {

        public static NiCris.BusinessObjects.BizMsgEx ToBusinessObject(NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx entity)
        {
            if (entity == null) return null;

            return new NiCris.BusinessObjects.BizMsgEx()
            {
                Id = entity.Id,

                EntityName = entity.EntityName,
                EntityAction = entity.EntityAction,

                EntityType = entity.EntityType,
                EntityValue = entity.EntityValue,

                EntityStatus = entity.EntityStatus,
                EntityErrorMessage = entity.EntityErrorMessage,
                EntityStackTrace = entity.EntityStackTrace,

                Date = entity.Date,
                User = entity.User,

                Serial = entity.Serial,
                Description = entity.Description,

                AppId = entity.AppId,
                ModuleId = entity.ModuleId,
                ServiceId = entity.ServiceId,
                StyleId = entity.StyleId,

                Roles = entity.Roles,

                RowVersion = VersionConverter.ToString(entity.rowversion)
            };
        }

        public static NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx ToEntity(NiCris.BusinessObjects.BizMsgEx model)
        {
            if (model == null) return null;

            return new NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx()
            {
                Id = model.Id,

                EntityName = model.EntityName,
                EntityAction = model.EntityAction,

                EntityType = model.EntityType,
                EntityValue = model.EntityValue,

                EntityStatus = model.EntityStatus,
                EntityErrorMessage = model.EntityErrorMessage,
                EntityStackTrace = model.EntityStackTrace,

                Date = model.Date,
                User = model.User,

                Serial = model.Serial,
                Description = model.Description,

                AppId = model.AppId,
                ModuleId = model.ModuleId,
                ServiceId = model.ServiceId,
                StyleId = model.StyleId,

                Roles = model.Roles,

                rowversion = VersionConverter.ToBinary(model.RowVersion)
            };
        }

    }
}
