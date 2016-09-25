using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slair.Core.Model.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Slair.Core.Dal.Abstractions
{
	public class EntityBaseRepository<T, U> : IEntityBaseRepository<T, U>
			where U : class, IEntity<T>, new()
	{

		private DbContext	_context;
		private DbSet<U>	_table;

		public EntityBaseRepository (DbContext context)
		{
			this._context	= context;
			this._table		= _context.Set<U> ( );
		}

		public virtual IEnumerable<U> GetAll ( )
		{
			return this._table.AsEnumerable ( );
		}

		public virtual int Count ( )
		{
			return this._table.Count ( );
		}

		public virtual IEnumerable<U> AllIncluding (params Expression<Func<U, object>>[] includeProperties)
		{
			IQueryable<U> query = this._table;
			foreach (var includeProperty in includeProperties) {
				query = query.Include (includeProperty);
			}
			return query.AsEnumerable ( );
		}

		public U GetSingle (T id)
		{
			return this._table.FirstOrDefault (x => EqualityComparer<T>.Default.Equals (x.Id, id));
		}

		public U GetSingle (Expression<Func<U, bool>> predicate)
		{
			return this._table.FirstOrDefault (predicate);
		}

		public U GetSingle (Expression<Func<U, bool>> predicate, params Expression<Func<U, object>>[] includeProperties)
		{
			IQueryable<U> query = this._table;
			foreach (var includeProperty in includeProperties) {
				query = query.Include (includeProperty);
			}

			return query.Where (predicate).FirstOrDefault ( );
		}

		public virtual IEnumerable<U> FindBy (Expression<Func<U, bool>> predicate)
		{
			return this._table.Where (predicate);
		}

		public virtual void Add (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			this._table.Add (entity);
		}

		public virtual void Update (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			_context.Attach (dbEntityEntry);
		}
		public virtual void Delete (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			dbEntityEntry.State = EntityState.Deleted;
		}

		public virtual void DeleteWhere (Expression<Func<U, bool>> predicate)
		{
			IEnumerable<U> entities = this._table.Where (predicate);

			foreach (var entity in entities) {
				_context.Entry<U> (entity).State = EntityState.Deleted;
			}
		}

		public virtual void Commit ( )
		{
			_context.SaveChanges ( );
		}
	}

	public class EntityBaseRepository<T> : EntityBaseRepository<int, T>, IEntityBaseRepository<T>
	where T : class, IEntity<int>, new()
	{
		public EntityBaseRepository (DbContext context) : base (context)
		{
		}
	}
}
