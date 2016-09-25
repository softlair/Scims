﻿using Slair.Core.Dal.Abstractions;
using Slair.Core.Model.Abstractions;
using Slair.Scims.Model;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Abstractions
{
	public interface ITaskInfoRepository<T> : IEntityBaseRepository<T>
		where T : class, IEntity<int>
	{

	}
}
