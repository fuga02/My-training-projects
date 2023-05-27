﻿using ClassRoomData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassRoomData.Contexts.Configurations;

public class UserSchoolConfiguration:IEntityTypeConfiguration<UserSchool>
{
    public void Configure(EntityTypeBuilder<UserSchool> builder)
    {
        builder.ToTable("user_schools");
        builder.HasKey(userSchool => new { userSchool.UserId, userSchool.SchoolId });
        builder.HasOne(userSchool => userSchool.User)
            .WithMany(user => user.UserSchools)
            .HasForeignKey(userSchool => userSchool.UserId);
        builder.HasOne(userSchool => userSchool.School)
            .WithMany(school => school.UserSchools)
            .HasForeignKey(userSchool => userSchool.SchoolId);
    }
}