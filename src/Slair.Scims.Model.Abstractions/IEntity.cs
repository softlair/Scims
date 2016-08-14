namespace Slair.Scims.Model.Abstractions
{
	public interface IEntity<T>
	{
		T Id { get; set; } // Key can be of any time like auto increment integer or a GUID
	}
}
