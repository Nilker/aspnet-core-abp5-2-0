


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XyAuto.It.Test;

namespace XyAuto.It.EntityMapper.Books
{
    public class BookCfg : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book>
            builder)
        {

            builder.ToTable("Books", YoYoAbpefCoreConsts.SchemaNames.CMS);

            builder.Property(a => a.Name).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.Surname).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.EmailAddress).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}


