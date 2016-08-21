using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slair.Core.Model.Abstractions;
using Slair.Scims.Dal.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Slair.Core.Dal.Abstractions
{
	public class EntityBaseRepository<T, U> : IEntityBaseRepository<T, U>
			where U : class, IEntity<T>, new()
	{

		private DbContext _context;

		public EntityBaseRepository (DbContext context)
		{
			_context = context;
		}

		public virtual IEnumerable<U> GetAll ( )
		{
			return _context.Set<U> ( ).AsEnumerable ( );
		}

		public virtual int Count ( )
		{
			return _context.Set<U> ( ).Count ( );
		}

		public virtual IEnumerable<U> AllIncluding (params Expression<Func<U, object>>[] includeProperties)
		{
			IQueryable<U> query = _context.Set<U> ( );
			foreach (var includeProperty in includeProperties) {
				query = query.Include (includeProperty);
			}
			return query.AsEnumerable ( );
		}

		public U GetSingle (T id)
		{
			return _context.Set<U> ( ).FirstOrDefault (x => EqualityComparer<T>.Default.Equals (x.Id, id));
		}

		public U GetSingle (Expression<Func<U, bool>> predicate)
		{
			return _context.Set<U> ( ).FirstOrDefault (predicate);
		}

		public U GetSingle (Expression<Func<U, bool>> predicate, params Expression<Func<U, object>>[] includeProperties)
		{
			IQueryable<U> query = _context.Set<U> ( );
			foreach (var includeProperty in includeProperties) {
				query = query.Include (includeProperty);
			}

			return query.Where (predicate).FirstOrDefault ( );
		}

		public virtual IEnumerable<U> FindBy (Expression<Func<U, bool>> predicate)
		{
			return _context.Set<U> ( ).Where (predicate);
		}

		public virtual void Add (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			_context.Set<U> ( ).Add (entity);
		}

		public virtual void Update (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			dbEntityEntry.State = EntityState.Modified;
		}
		public virtual void Delete (U entity)
		{
			EntityEntry dbEntityEntry = _context.Entry<U> (entity);
			dbEntityEntry.State = EntityState.Deleted;
		}

		public virtual void DeleteWhere (Expression<Func<U, bool>> predicate)
		{
			IEnumerable<U> entities = _context.Set<U> ( ).Where (predicate);

			foreach (var entity in entities) {
				_context.Entry<U> (entity).State = EntityState.Deleted;
			}
		}

		public virtual void Commit ( )
		{
			_context.SaveChanges ( );
		}
	}
}
