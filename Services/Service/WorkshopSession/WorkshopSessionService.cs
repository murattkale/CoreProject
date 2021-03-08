public interface IWorkshopSessionService : IGenericRepo<WorkshopSession> { }
public class WorkshopSessionService : GenericRepo<myDBContext, WorkshopSession>, IWorkshopSessionService
{
    public WorkshopSessionService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

