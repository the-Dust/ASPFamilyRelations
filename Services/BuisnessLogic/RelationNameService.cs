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
    public class RelationNameService : IRelationNameService
    {
        private IRelationNameRepository relationNameRepository = null;

        public RelationNameService(IRelationNameRepository relationNameRepository)
        {
            this.relationNameRepository = relationNameRepository;
        }

        public IEnumerable<RelationName> GetRelationNames()
        {
            return relationNameRepository.GetRelationNames();
        }

    }
}
