using Microsoft.EntityFrameworkCore;
using Skinet_Core.Entities;
using Skinet_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet_Infrastructure.Data
{
   public  class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesceding != null)
            {
                query = query.OrderByDescending(spec.OrderByDesceding);
            }
            if(spec.IsPagingEnabled)
            {
                query =query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Include.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
