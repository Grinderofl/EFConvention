using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using EFConvention;

namespace WebTest.Models
{
    public class ItemSeed : IEntitySeed<Item>
    {
        public void Seed(DbSet<Item> entity)
        {
            entity.AddOrUpdate(a => a.Data, new Item() {Data = "Hello world", Created = DateTime.Now});
        }
    }
}