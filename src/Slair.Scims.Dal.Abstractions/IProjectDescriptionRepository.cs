﻿using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Dal.Abstractions
{
	public interface IProjectDescriptionRepository<T> : IEntityBaseRepository<IProjectDescription<T>>
	{

	}
}