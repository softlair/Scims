using System;
using Microsoft.EntityFrameworkCore;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal
{
	public class AdministrationContext : DbContext
	{
		public DbSet<TaskDescription> Tasks { get; set; }
		public DbSet<ProjectDescription> Projects { get; set; }

		public AdministrationContext(DbContextOptions<AdministrationContext> options) : base (options)
		{

		}

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TaskDescription> ( )
				.HasMany (t => t.SubTasks);

			modelBuilder.Entity<ProjectDescription> ( )
				.HasMany (p => p.Tasks);
		}
	}
}
