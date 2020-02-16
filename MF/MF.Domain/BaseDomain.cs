using Microsoft.AspNet.OData.Query;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace MF.Domain
{
    public class BaseDomain
    {
        public int Id { get; set; }
    }
    public class KeyValueGeneric<t,y>
    {
        public t Id { get; set; }
        public y Value { get; set; }
    }

    public static class ODataQueryOptionsExtensions
    {
        public static Expression<Func<T, bool>> GetFilter<T>(this ODataQueryOptions<T> options)
        {
            // The same trick as in the linked post
            IQueryable query = Enumerable.Empty<T>().AsQueryable();
            query = options.Filter.ApplyTo(query, new ODataQuerySettings());
            // Extract the predicate from `Queryable.Where` call
            var call = query.Expression as MethodCallExpression;
            if (call != null && call.Method.Name == nameof(Queryable.Where) && call.Method.DeclaringType == typeof(Queryable))
            {
                var predicate = ((UnaryExpression)call.Arguments[1]).Operand;
                return (Expression<Func<T, bool>>)predicate;
            }
            return null;
        }
    }
}
