namespace QVZ.DAL
{
	public interface IEditableDatabaseContext : IDatabaseContext
	{
		int SaveChanges(string userObjectId);
	}
}
