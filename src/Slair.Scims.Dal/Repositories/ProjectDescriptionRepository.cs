using Microsoft.EntityFrameworkCore;
using Slair.Core.Dal.Abstractions;
using Slair.Scims.Dal.Abstractions;
using Slair.Scims.Dal.Repositories;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Repositories
{
	public class ProjectDescriptionRepository : EntityBaseRepository<ProjectDescription>, IProjectDescriptionRepository
	{
		public ProjectDescriptionRepository (ScimsDbContext context)
			 : base (context)
		{

		}
	}
}
