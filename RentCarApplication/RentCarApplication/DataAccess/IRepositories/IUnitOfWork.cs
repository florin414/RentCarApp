namespace RentCarApplication.DataAccess.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<User, string> UserRepository { get; set; }
    IBaseRepository<Rent, int> RentRepository { get; set; }
    IBaseRepository<Comment, int> CommentRepository { get; set; }
    IBaseRepository<Car, int> CarRepository { get; set; }

    void Save();
}
