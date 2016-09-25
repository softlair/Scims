using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;

namespace Slair.Scims.Model
{
	public class UserProjectRecord : EditableEntityBase<string>, IUserProjectRecord<string>
	{
		public string UserId { get; set; }

		public ICollection<IProjectDescription<string>> Projects { get; set; }
	}
}
