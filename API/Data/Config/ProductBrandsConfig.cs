using System.ComponentModel.DataAnnotations.Schema;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config
{
    public class ProductBrandsConfig : IEntityTypeConfiguration<ProductBrand>
    {

        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
           // builder.Property(a => a.Id).UseIdentityColumn();
        }
    }
}