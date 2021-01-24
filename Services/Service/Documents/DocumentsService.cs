public interface IDocumentsService : IGenericRepo<Documents> { }
public class DocumentsService : GenericRepo<myDBContext, Documents>, IDocumentsService
{
    public DocumentsService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

