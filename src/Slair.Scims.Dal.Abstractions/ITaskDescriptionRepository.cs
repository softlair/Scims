﻿using Slair.Core.Model.Abstractions;
using Slair.Core.Dal.Abstractions;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Abstractions
{
	public interface ITaskDescriptionRepository<T> : IEntityBaseRepository<ITaskDescription<T>>
	{

	}
}
