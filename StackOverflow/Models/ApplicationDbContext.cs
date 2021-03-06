﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StackOverflow.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public ApplicationDbContext()
		{

		}


		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<QuestionComment> QuestionComments { get; set; }
		public DbSet<AnswerComment> AnswerComments { get; set; }
        public DbSet<Profile> Profiles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
				.HasMaxLength(255));

			builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
				.HasMaxLength(255));

			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
				.HasMaxLength(255));

			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		   => optionsBuilder
			   .UseMySql(@"Server=localhost;Port=8889;database=StackOverflow;uid=root;pwd=root;");
	}
}
