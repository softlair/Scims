﻿using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Abstractions
{
	public interface IDailyTasksRecordRepository<T> : IEntityBaseRepository<IDailyTasksRecord<T>>
	{

	}
}