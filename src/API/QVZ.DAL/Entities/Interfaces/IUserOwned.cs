namespace QVZ.DAL.Entities.Interfaces
{
	public interface IUserOwned
	{
		int UserId { get; set; }

		User User { get; set; }
	}
}
