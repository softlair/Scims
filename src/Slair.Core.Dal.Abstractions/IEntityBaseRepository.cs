using Slair.Core.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Slair.Scims.Dal.Abstractions
{
	public interface IEntityBaseRepository<T, U> 
		where U : class, IEntity<T>, new()
	{
		IEnumerable<U> AllIncluding (params Expression<Func<U, object>>[] includeProperties);
		IEnumerable<U> GetAll ( );
		int Count ( );
		U GetSingle (T id);
		U GetSingle (Expression<Func<U, bool>> predicate);
		U GetSingle (Expression<Func<U, bool>> predicate, params Expression<Func<U, object>>[] includeProperties);
		IEnumerable<U> FindBy (Expression<Func<U, bool>> predicate);
		void Add (U entity);
		void Update (U entity);
		void Delete (U entity);
		void DeleteWhere (Expression<Func<U, bool>> predicate);
		void Commit ( );
	}
}
