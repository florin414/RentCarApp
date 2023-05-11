namespace RentCarApplication.DataAccess.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly RentCarContext _dbContext;
    private bool disposedValue;

    public IBaseRepository<User, string> UserRepository { get; set; }
    public IBaseRepository<Rent, int> RentRepository { get; set; }
    public IBaseRepository<Comment, int> CommentRepository { get; set; }
    public IBaseRepository<Car, int> CarRepository { get; set; }

    public UnitOfWork(
        RentCarContext dbContext,
        IBaseRepository<User, string> userRepository,
        IBaseRepository<Rent, int> rentRepository,
        IBaseRepository<Comment, int> commentRepository,
        IBaseRepository<Car, int> carRepository
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        RentRepository = rentRepository ?? throw new ArgumentNullException(nameof(rentRepository));
        CommentRepository =
            commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        CarRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _dbContext?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
