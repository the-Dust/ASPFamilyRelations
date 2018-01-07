using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.BuisnessLogic.Base
{
    public interface IRelationService
    {
        IEnumerable<Relation> GetRelations();

        IEnumerable<Relation> GetRelations(Expression<Func<Relation, bool>> func);

        Relation GetRelation(int id);

        Relation GetRelation(Expression<Func<Relation, bool>> func);

        bool RemoveRelation(int id);

        void UpdateRelation(Relation relation);

        void AddRelation(Relation relation);
    }
}
