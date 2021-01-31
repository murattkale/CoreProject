public interface IUserClientSessionService : IGenericRepo<UserClientSession> { }
public class UserClientSessionService : GenericRepo<myDBContext, UserClientSession>, IUserClientSessionService
{
    public UserClientSessionService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

