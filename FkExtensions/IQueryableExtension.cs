using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using FkExtensions.Models;

namespace FkExtensions;

public static class IQueryableExtension
{
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                     int page, int pageSize) where T : class
    {
        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.RowCount = query.Count();

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = query.Skip(skip).Take(pageSize).ToList();

        return result;
    }

    public static PagedResult<T> GetPagedAndOrderByAttribute<T>(this IQueryable<T> query,
                                     int page, int pageSize, string orderBy, bool orderByDesc) where T : class
    {
        var props = typeof(T).GetProperties();
        var orderByProperty = props.FirstOrDefault(x => x.GetCustomAttribute<ColumnAttribute>()?.Name == orderBy);

        // TODO 對應不到排序欄位, 是否例外處理
        if (orderByProperty == null)
            throw new ArgumentException("orderBy");


        var orderMethod = orderByDesc ? "OrderByDescending" : "OrderBy";
        var parameter = Expression.Parameter(typeof(T), "item");
        var expression = orderByProperty.Name.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);
        var keySelector = Expression.Lambda(expression, parameter);
        var methodCall = Expression.Call(typeof(Queryable), orderMethod, new[] { parameter.Type, expression.Type }, query.Expression, Expression.Quote(keySelector));

        return ((IOrderedQueryable<T>)query.Provider.CreateQuery(methodCall)).GetPaged(page, pageSize);
    }

}