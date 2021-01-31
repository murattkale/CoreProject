public interface IUserClientService : IGenericRepo<UserClient> { }
public class UserClientService : GenericRepo<myDBContext, UserClient>, IUserClientService
{
    public UserClientService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

