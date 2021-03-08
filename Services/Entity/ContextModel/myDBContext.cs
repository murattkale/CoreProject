using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public partial class myDBContext : DbContext
{
    public myDBContext()
    {
    }

    public myDBContext(DbContextOptions<myDBContext> options)
        : base(options)
    {

    }

    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<UserClient> UserClient { get; set; }
    public virtual DbSet<UserClientSession> UserClientSession { get; set; }
    public virtual DbSet<Workshop> Workshop { get; set; }
    public virtual DbSet<Section> Section { get; set; }
    public virtual DbSet<Content> Content { get; set; }
    public virtual DbSet<ResponseData> ResponseData { get; set; }
    public virtual DbSet<Documents> Documents { get; set; }
    public virtual DbSet<ActionData> ActionData { get; set; }
    public virtual DbSet<WorkshopSession> WorkshopSession { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=94.73.170.92;Initial Catalog=u5249316_wip;MultipleActiveResultSets=true;User ID=u5249316_wip;Password=VFlw97O6QPnn66A;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "mySchema"));

        }
    }

    private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(myDBContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ConfigureGlobalFiltersMethodInfo
                .MakeGenericMethod(entityType.ClrType)
                .Invoke(this, new object[] { modelBuilder, entityType });
        }


        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }

    protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType) where TEntity : class
    {
        if (entityType.BaseType != null || !ShouldFilterEntity<TEntity>(entityType)) return;
        var filterExpression = CreateFilterExpression<TEntity>();
        if (filterExpression == null) return;
        //if (entityType.GetType().IsInterface==true)
        //if (false)
        //    modelBuilder.Query<TEntity>().HasQueryFilter(filterExpression);
        //else
        modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
    }

    protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
    {
        return typeof(IBaseModel).IsAssignableFrom(typeof(TEntity));
    }

    protected Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
    {
        Expression<Func<TEntity, bool>> expression = null;

        if (typeof(IBaseModel).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> removedFilter = e => (DateTime)((IBaseModel)e).IsDeleted == null;
            expression = expression == null ? removedFilter : CombineExpressions(expression, removedFilter);
        }

        return expression;
    }

    protected Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
    {
        return Helpers.Combine(expression1, expression2);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

