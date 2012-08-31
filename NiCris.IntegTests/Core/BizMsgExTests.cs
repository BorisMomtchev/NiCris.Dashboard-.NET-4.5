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
    }
}
