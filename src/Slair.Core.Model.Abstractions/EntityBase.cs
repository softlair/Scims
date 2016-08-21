namespace Slair.Core.Model.Abstractions
{
	public abstract class EntityBase<T> : IEntity<T>
	{
		public virtual T Id { get; set; }
	}
}
