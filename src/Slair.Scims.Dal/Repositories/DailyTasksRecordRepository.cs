﻿using Microsoft.EntityFrameworkCore;
using Slair.Core.Dal.Abstractions;
using Slair.Scims.Dal.Abstractions;
using Slair.Scims.Dal.Repositories;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Repositories
{
	public class DailyTasksRecordRepository : EntityBaseRepository<DailyTasksRecord>, IDailyTasksRecordRepository
	{
		public DailyTasksRecordRepository (ScimsDbContext context)
			 : base (context)
		{

		}
	}
}