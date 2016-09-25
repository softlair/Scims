using Slair.Core.Model.Abstractions;
using System;
using System.Collections.Generic;

namespace Slair.Scims.Model.Abstractions
{
	public interface IUserProjectRecord<T> : IEditableEntity<T>
	{
		string UserId { get; set; }

		ICollection<IProjectDescription<T>> Projects { get; set; }
	}
}
