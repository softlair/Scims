using System;
using Microsoft.EntityFrameworkCore;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal
{
	public class DailyTasksContext : DbContext
	{
		public DbSet<DailyTasksRecord>		Tasks		{ get; set; }

		public DailyTasksContext(DbContextOptions<AdministrationContext> options) : base (options)
		{
		}

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DailyTasksRecord> ( )
				.HasMany (t => t.Tasks);
		}
	}
}
