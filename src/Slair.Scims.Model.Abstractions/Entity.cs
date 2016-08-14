namespace Slair.Scims.Model.Abstractions
{
	//T: Entity Key data type
	public abstract class Entity<T> : IEntity<T>
	{
		public virtual T Id { get; set; }
	}
}
