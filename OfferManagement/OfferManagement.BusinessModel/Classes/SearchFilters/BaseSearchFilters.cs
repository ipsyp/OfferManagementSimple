﻿using System.Data.Objects.DataClasses;

namespace OfferManagement.BusinessModel
{
    public abstract class BaseSearchFilters<TEntity> where TEntity : EntityObject
    {
        public virtual Imis.Domain.EF.Search.Criteria<TEntity> GetExpression()
        {
            return Imis.Domain.EF.Search.Criteria<TEntity>.Empty;
        }
    }
}