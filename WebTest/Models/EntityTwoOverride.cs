using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using EFConvention;

namespace WebTest.Models
{
    public class EntityTwoOverride : IModelBuilderOverride<EntityTwo>
    {
        public void Configure(EntityTypeConfiguration<EntityTwo> entity)
        {
            entity.ToTable("MyLollableEntities");
        }
    }
}