using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
<<<<<<< HEAD
using EFConventions.Interceptors;
=======
using EFAutomation.Interceptors;
>>>>>>> cf4659b760e07050a0426662dd0cba0acde539aa
using WebTest.Models;

namespace WebTest.Listeners
{
    public class UpdateEventListener : IPreInsertEventListener
    {
        public void OnInsert(DbEntityEntry entityEntry)
        {
            var item = entityEntry.Entity as Item;
            if (item != null)
            {
                item.Created = DateTime.Now;
                item.Modified = DateTime.Now;
            }
        }
    }
}