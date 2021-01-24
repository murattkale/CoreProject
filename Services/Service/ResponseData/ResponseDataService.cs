public interface IResponseDataService : IGenericRepo<ResponseData> { }
public class ResponseDataService : GenericRepo<myDBContext, ResponseData>, IResponseDataService
{
    public ResponseDataService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

