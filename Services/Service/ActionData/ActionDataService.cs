public interface IActionDataService : IGenericRepo<ActionData> { }
public class ActionDataService : GenericRepo<myDBContext, ActionData>, IActionDataService
{
    public ActionDataService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

