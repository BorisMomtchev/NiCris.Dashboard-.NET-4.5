using NiCris.Core.Validation;
using NiCris.DataAccess.Interfaces;
using NiCris.DataAccess.SQL.LinqToSQL;
using NiCris.DataAccess.SQL.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Linq;

namespace NiCris.DataAccess.SQL.Repositories
{
    public class BizMsgExRepository : IBizMsgExRepository
    {
        #region ICRUDRepository<BizMsgEx> Members

        public IList<BusinessObjects.BizMsgEx> GetAll()
        {
            using (Database db = DataContextFactory.CreateContext())
            {
                return db.BizMsgsExes.Select(x => BizMsgExMapper.ToBusinessObject(x)).ToList();
            }
        }

        public BusinessObjects.BizMsgEx GetById(int id)
        {
            using (Database db = DataContextFactory.CreateContext())
            {
                return BizMsgExMapper.ToBusinessObject(db.BizMsgsExes
                    .Where(x => x.Id == id)
                    .SingleOrDefault());
            }
        }

        public int Insert(BusinessObjects.BizMsgEx model)
        {
            // Validate the BO
            var errorInfo = NiCrisValidator.Check(model);
            if (errorInfo.Count() > 0)
                throw new ValidationException("Validation error(s) occurred! Please make sure all validation rules are met.");

            NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx entity = BizMsgExMapper.ToEntity(model);

            using (Database db = DataContextFactory.CreateContext())
            {
                try
                {
                    db.BizMsgsExes.InsertOnSubmit(entity);
                    db.SubmitChanges();

                    model.Id = entity.Id;
                    model.RowVersion = VersionConverter.ToString(entity.rowversion);
                    return entity.Id;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
                        conflict.Resolve(RefreshMode.KeepCurrentValues);

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        throw new Exception("A concurrency error occurred!");
                    }

                    return entity.Id;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was an error inserting the record! " + ex.Message);
                }
            }

        }

        public int Update(BusinessObjects.BizMsgEx model)
        {
            // Validate the BO
            var errorInfo = NiCrisValidator.Check(model);
            if (errorInfo.Count() > 0)
                throw new ValidationException("Validation error(s) occurred! Please make sure all validation rules are met.");

            NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx entity = BizMsgExMapper.ToEntity(model);

            using (Database db = DataContextFactory.CreateContext())
            {
                try
                {
                    db.BizMsgsExes.Attach(entity, true);
                    db.SubmitChanges();

                    model.Id = entity.Id;
                    model.RowVersion = VersionConverter.ToString(entity.rowversion);
                    return entity.Id;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
                        conflict.Resolve(RefreshMode.KeepCurrentValues);

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        throw new Exception("A concurrency error occurred!");
                    }

                    return entity.Id;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was an error updating the record! " + ex.Message);
                }
            }

        }

        public void Delete(BusinessObjects.BizMsgEx model)
        {
            NiCris.DataAccess.SQL.LinqToSQL.BizMsgsEx entity = BizMsgExMapper.ToEntity(model);

            using (Database db = DataContextFactory.CreateContext())
            {
                try
                {
                    db.BizMsgsExes.Attach(entity, false);
                    db.BizMsgsExes.DeleteOnSubmit(entity);
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
                        conflict.Resolve(RefreshMode.KeepCurrentValues);

                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (ChangeConflictException)
                    {
                        throw new Exception("A concurrency error occurred!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("There was an error updating the record! " + ex.Message);
                }
            }
        }

        #endregion
    }
}
