using System;
using Microsoft.EntityFrameworkCore;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal
{
	public class ScimsDbContext : DbContext
	{
		public DbSet<TaskInfo> TaskInfos { get; set; }
		public DbSet<TaskDescription> TaskDescriptions { get; set; }
		public DbSet<ShiftDescription> ShiftDescriptions { get; set; }
		public DbSet<ProjectDescription> ProjectDescriptions { get; set; }
		public DbSet<DailyTasksRecord> DailyTasksRecords { get; set; }
		

		public ScimsDbContext(DbContextOptions<ScimsDbContext> options) : base (options)
		{

		}

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TaskDescription> ( ).Property (p => p.ProjectId).IsRequired ( );
			modelBuilder.Entity<TaskDescription> ( )
				.HasOne<IProjectDescription<string>> (p => p.Project)
				.WithMany ( );

			modelBuilder.Entity<ProjectDescription> ( )
				.HasMany<ITaskDescription<string>> (p => p.Tasks)
				.WithOne ( );
		}
	}
}
