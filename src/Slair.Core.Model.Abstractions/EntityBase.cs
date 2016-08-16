namespace Slair.Core.Model.Abstractions
{
	//T: Entity Key data type
	public abstract class EntityBase<T> : IEntity<T>
	{
		public virtual T Id { get; set; }
	}
}
