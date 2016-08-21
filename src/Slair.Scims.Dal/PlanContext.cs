using System;
using Microsoft.EntityFrameworkCore;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal
{
	public class PlanContext : DbContext
	{
		public DbSet<TaskInfo>		Tasks		{ get; set; }

		public PlanContext(DbContextOptions<PlanContext> options) : base (options)
		{
		}

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
		}
	}
}
