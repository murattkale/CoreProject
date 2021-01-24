public interface IContentService : IGenericRepo<Content> { }
public class ContentService : GenericRepo<myDBContext, Content>, IContentService
{
    public ContentService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

