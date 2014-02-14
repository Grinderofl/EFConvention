using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using EFConvention;

namespace WebTest.Models
{
    public class AllSeed : IContextSeed
    {
        public void Seed(IContext context)
        {
            context.Set<EntityTwo>().AddOrUpdate(x => x.Name, new EntityTwo() {Name = "My entity"});
        }
    }
}