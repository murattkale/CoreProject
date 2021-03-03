
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


public interface IGenericRepo<T> where T : class
{
    RModel<T> InsertOrUpdate(T model);
    DTResult<T> GetPaging(
        Expression<Func<T, bool>> filter = null
       , bool AsNoTracking = true
       , DTParameters<T> param = null
       , bool IsDeletedShow = false
       , params Expression<Func<T, object>>[] includes
       );

    DTResult2<T> GetPaging2(
      Expression<Func<T, bool>> filter = null
     , bool AsNoTracking = true
     , DTParameters<T> param = null
     , bool IsDeletedShow = false
     , params Expression<Func<T, object>>[] includes
     );

    RModel<T> Where(
          Expression<Func<T, bool>> filter = null
          , bool AsNoTracking = true
          , bool IsDeletedShow = false
          , params Expression<Func<T, object>>[] includes
          );

    RModel<T> Add(T t);
    RModel<T> Delete(int id);
    RModel<T> Delete(T t);
    RModel<T> Update(T t);
    void Dispose();

}
