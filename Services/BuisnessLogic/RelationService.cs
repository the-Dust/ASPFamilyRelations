using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Linq.Expressions;
using DataAccess.Repositories.Base;

namespace Services.BuisnessLogic
{
    public class RelationService : IRelationService
    {
        private IRelationRepository relationRepository = null;

        public RelationService(IRelationRepository relationRepository)
        {
            this.relationRepository = relationRepository;
        }

        public void AddRelation(Relation relation)
        {
            relationRepository.AddRelation(relation);
        }

        public Relation GetRelation(int id)
        {
            return relationRepository.GetRelation(id);
        }

        public Relation GetRelation(Expression<Func<Relation, bool>> func)
        {
            return relationRepository.GetRelation(func);
        }

        public IEnumerable<Relation> GetRelations()
        {
            return relationRepository.GetRelations();
        }

        public IEnumerable<Relation> GetRelations(Expression<Func<Relation, bool>> func)
        {
            return relationRepository.GetRelations(func);
        }

        public bool RemoveRelation(int id)
        {
            return relationRepository.RemoveRelation(id);
        }

        public void UpdateRelation(Relation relation)
        {
            relationRepository.UpdateRelation(relation);
        }
    }
}
