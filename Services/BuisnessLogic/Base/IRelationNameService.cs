using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.BuisnessLogic.Base
{
    public interface IRelationNameService
    {
        IEnumerable<RelationName> GetRelationNames();
    }
}
