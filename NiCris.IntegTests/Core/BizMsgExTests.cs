using NiCris.BusinessObjects;
using NiCris.DataAccess.Interfaces;
using NiCris.DataAccess.SQL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NiCris.IntegTests.Core
{
    [TestFixture]
    public class BizMsgExTests
    {
        IBizMsgExRepository GetRepository()
        {
            return new BizMsgExRepository();
        }

        [Test]
        public void BizMsgEx_Populate()
        {
            // Arrange -> Act -> Assert
            var repository = GetRepository();

            var result = new List<BizMsgEx>();
            for (int i = 0; i < 20; i++)
            {
                result.Add(new BizMsgEx()
                {
                    // Id = i,
                    EntityName = "EntityName: " + i.ToString(),
                    EntityAction = "EntityAction: " + i.ToString(),

                    EntityValue = "EntityValue: " + i.ToString(),
                    EntityType = "EntityType: " + i.ToString(),

                    Date = DateTime.Now.AddDays(-i),
                    User = "User: " + i.ToString()
                });
            }

            // Save to db
            foreach (var item in result)
                repository.Insert(item);
        }

        [Test]
        public void BizMsgEx_Delete()
        {
            // Arrange -> Act -> Assert
            var repository = GetRepository();

            var all = repository.GetAll();

            foreach (var item in all)
                repository.Delete(item);
        }

        [Test]
        public void BizMsg_CRUD_Test()
        {
            // Arrange -> Act -> Assert
            var repository = GetRepository();

            var newBizMsgEx = new BizMsgEx
            {
                // All required fields have valid values here...
                EntityName = "EntityName:XYZ",
                EntityAction = "EntityAction:ABC",
                EntityValue = "EntityValue:123",
                EntityType = "EntityType",
                Date = DateTime.Now,
                User = "User:XYZ",
            };

            // save to db
            int id = repository.Insert(newBizMsgEx);

            // get from db
            var savedBizMsgEx = repository.GetById(id);
            Assert.AreEqual("EntityValue:123", savedBizMsgEx.EntityValue);

            // update
            savedBizMsgEx.EntityValue = "UPDATED_EntityValue:123";
            int id_updated = repository.Update(savedBizMsgEx);
            Assert.AreEqual(id, id_updated);

            // delete
            repository.Delete(savedBizMsgEx);
        }
    }
}
