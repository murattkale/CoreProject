public interface ISectionService : IGenericRepo<Section> { }
public class SectionService : GenericRepo<myDBContext, Section>, ISectionService
{
    public SectionService(myDBContext context, IBaseSession sessionInfo) : base(context, sessionInfo) { }
}

