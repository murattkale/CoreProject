public interface IWorkshopService : IGenericRepo<Workshop> { }
public class WorkshopService : GenericRepo<myDBContext, Workshop>, IWorkshopService
{
    public WorkshopService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

