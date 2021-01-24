public interface IUserService : IGenericRepo<User> { }
public class UserService : GenericRepo<myDBContext, User>, IUserService
{
    public UserService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

