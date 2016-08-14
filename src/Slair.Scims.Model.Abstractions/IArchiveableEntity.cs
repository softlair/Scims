using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slair.Scims.Model.Abstractions
{
	// Rules for Model that cannot be deleted from the DB
	public interface IArchiveableEntity
	{
		// true: Entity is deleted
		// false: Entity is active (Default)
		bool ArchiveFlag { get; set; }
	}
}
