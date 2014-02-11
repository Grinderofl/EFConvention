using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EFAutomation;

namespace WebTest.Models
{
    public class ItemOverride : IModelBuilderOverride<Item>
    {
        public void Configure(EntityTypeConfiguration<Item> entity)
        {
            entity.ToTable("MyPersonalItems");
        }
    }
}