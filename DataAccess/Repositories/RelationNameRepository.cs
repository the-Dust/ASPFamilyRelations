using DataAccess.Entities;
using DataAccess.Repositories.Base;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class RelationNameRepository : AbstractRepository, IRelationNameRepository
    {
        public IEnumerable<RelationName> GetRelationNames()
        {
            return context.RelationNames;
        }
    }
}
