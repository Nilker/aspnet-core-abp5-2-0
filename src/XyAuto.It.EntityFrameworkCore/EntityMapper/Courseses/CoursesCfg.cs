


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XyAuto.It.Test;

namespace XyAuto.It.EntityMapper.Courseses
{
    public class CoursesCfg : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses>
            builder)
        {

            builder.ToTable("Courseses", YoYoAbpefCoreConsts.SchemaNames.CMS);

            builder.Property(a => a.CoursesID).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.CourseName).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
            builder.Property(a => a.Standard).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}

