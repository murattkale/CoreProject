using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


public class GenericRepo<C, T> : IGenericRepo<T> where T : class, IBaseModel where C : DbContext, new()
{

    private C _context = new C();
    public C Context
    {

        get { return _context; }
        set { _context = value; }
    }


    protected IBaseSession sessionInfo;

    public GenericRepo(C _context, IBaseSession sessionInfo)
    {
        this.sessionInfo = sessionInfo;
        this._context = _context;
    }


    public RModel<T> InsertOrUpdate(T model)
    {
        RModel<T> res = new RModel<T>();
        if (model.Id > 0)
            res = Update(model);
        else
            res = Add(model);

        return res;
    }


    public DTResult<T> GetPaging(
        Expression<Func<T, bool>> filter = null
       , bool AsNoTracking = true
       , DTParameters<T> param = null
       , bool IsDeletedShow = false
       , params Expression<Func<T, object>>[] includes
       )
    {
        var query = Where(filter, AsNoTracking, IsDeletedShow, includes).Result;

        var GlobalSearchFilteredData = query.ToGlobalSearchInAllColumn<T>(param);
        var IndividualColSearchFilteredData = GlobalSearchFilteredData.ToIndividualColumnSearch(param);
        var SortedFilteredData = IndividualColSearchFilteredData.ToSorting(param);
        var SortedData = SortedFilteredData.ToPagination(param);

        var rSortedData = SortedData.ToList();

        int Count = query.Count();

        var resultData = new DTResult<T>
        {
            draw = param.Draw,
            data = rSortedData,
            recordsFiltered = Count,
            recordsTotal = Count
        };

        return resultData;

    }

    public RModel<T> Where(
        Expression<Func<T, bool>> filter = null
        , bool AsNoTracking = true
        , bool IsDeletedShow = false
        , params Expression<Func<T, object>>[] includes
        )
    {
        RModel<T> res = new RModel<T>();
        try
        {
            var query = _context.Set<T>() as IQueryable<T>;

            if (AsNoTracking)
                query = query.AsNoTracking();

            if (IsDeletedShow)
                query = query.IgnoreQueryFilters(); //Disable global query filters

            if (filter != null)
                query = query.Where(filter);

            if (includes != null && includes.Count() > 0)
            {
                if (IsDeletedShow)
                {
                    if (AsNoTracking)
                        query = includes.Aggregate(query, (current, include) => current.AsNoTracking().Include(include).IgnoreQueryFilters());
                    else
                        query = includes.Aggregate(query, (current, include) => current.Include(include).IgnoreQueryFilters());
                }
                else
                {
                    if (AsNoTracking)
                        query = includes.Aggregate(query, (current, include) => current.AsNoTracking().Include(include));
                    else
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

            }

            res.Result = query;
            res.RType = RType.OK;
        }
        catch (Exception ex)
        {
            res.Message = ex?.InnerException?.Message + "\n" + "\n" + ex?.Message;
            res.Ex = ex;
            res.RType = RType.Error;
        }
        return res;
    }


    public RModel<T> Add(T t)
    {
        RModel<T> res = new RModel<T>();
        try
        {
            t.CreaUser = sessionInfo._BaseModel.Id;
            t.CreaDate = DateTime.Now;
            _context.Set<T>().Add(t);
            res.ResultRow = t;
            res.RType = RType.OK;
        }
        catch (Exception ex)
        {
            res.Message = ex?.InnerException?.Message + "\n" + "\n" + ex?.Message;
            res.Ex = ex;
            res.RType = RType.Error;
        }

        return res;
    }
    public RModel<T> Delete(int id)
    {
        RModel<T> res = new RModel<T>();
        try
        {
            var t = Where(o => o.Id == id).ResultRow;
            t.IsDeleted = DateTime.Now;
            var upd = Update(t);
            res.ResultRow = t;
            res.RType = RType.OK;
        }
        catch (Exception ex)
        {
            res.Message = ex?.InnerException?.Message + "\n" + "\n" + ex?.Message;
            res.Ex = ex;
            res.RType = RType.Error;
        }
        return res;
    }
    public RModel<T> Delete(T t)
    {
        RModel<T> res = new RModel<T>();
        try
        {
            t.IsDeleted = DateTime.Now;
            var upd = Update(t);
            res.ResultRow = t;
            res.RType = RType.OK;
        }
        catch (Exception ex)
        {
            res.Message = ex?.InnerException?.Message + "\n" + "\n" + ex?.Message;
            res.Ex = ex;
            res.RType = RType.Error;
        }

        return res;
    }
    public RModel<T> Update(T t)
    {
        RModel<T> res = new RModel<T>();
        try
        {
            var dbEntityEntry = _context.Entry(t);
            dbEntityEntry.State = EntityState.Modified;
            dbEntityEntry.Property(o => o.CreaDate).IsModified = false;
            t.ModUser = sessionInfo._BaseModel.Id;
            t.ModDate = DateTime.Now;
            res.ResultRow = t;
            res.RType = RType.OK;
        }
        catch (Exception ex)
        {
            res.Message = ex?.InnerException?.Message + "\n" + "\n" + ex?.Message;
            res.Ex = ex;
            res.RType = RType.Error;
        }
        return res;
    }
    private bool disposed = false;
    protected void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}


