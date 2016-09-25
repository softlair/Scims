using System;
using Microsoft.EntityFrameworkCore;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Slair.Scims.Dal
{
	public class ScimsDbContext : DbContext
	{
		public DbSet<TaskInfo> TaskInfos { get; set; }
		public DbSet<TaskDescription> TaskDescriptions { get; set; }
		public DbSet<ShiftDescription> ShiftDescriptions { get; set; }
		public DbSet<ProjectDescription> ProjectDescriptions { get; set; }
		public DbSet<DailyTasksRecord> DailyTasksRecords { get; set; }
		public DbSet<UserProjectRecord> UserProjectRecords { get; set; }


		public ScimsDbContext (DbContextOptions<ScimsDbContext> options) : base (options)
		{

		}

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			//Task Description
			modelBuilder.Entity<TaskDescription> ( )
				.ToTable ("TaskDescription");
			modelBuilder.Entity<TaskDescription> ( )
				.HasMany<IProjectDescription<string>> (p => p.Projects);

			modelBuilder.Entity<TaskDescription> ( )
				.HasMany<ITaskDescription<string>> (s => s.SubTasks);

			//Project Description
			modelBuilder.Entity<ProjectDescription> ( )
				.ToTable ("ProjectDescription");
			modelBuilder.Entity<ProjectDescription> ( )
				.HasMany<ITaskDescription<string>> (p => p.Tasks);

			// Shift Description
			modelBuilder.Entity<ShiftDescription> ( )
				.ToTable ("ShiftDescription");

			// User Projects
			modelBuilder.Entity<UserProjectRecord> ( )
				.ToTable ("UserProjectRecord");
			modelBuilder.Entity<UserProjectRecord> ( )
				.HasMany<IProjectDescription<string>> (p => p.Projects);
		}
	}
}
