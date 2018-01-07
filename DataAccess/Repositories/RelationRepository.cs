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
    public class RelationRepository : AbstractRepository, IRelationRepository
    {
        public Relation GetRelation(int id)
        {
            return context.Relations.Include(x=>x.TargetPerson)
                .Include(x=>x.RelationName).FirstOrDefault(x => x.Id == id);
        }

        public Relation GetRelation(Expression<Func<Relation, bool>> func)
        {
            return context.Relations.Include(x => x.TargetPerson)
                .Include(x => x.RelationName).FirstOrDefault(func);
        }

        public IEnumerable<Relation> GetRelations()
        {
            return context.Relations;
        }

        public IEnumerable<Relation> GetRelations(Expression<Func<Relation, bool>> func)
        {
            return context.Relations.Where(func);
        }

        public bool RemoveRelation(int id)
        {
            Relation relation = GetRelation(id);

            Relation mirrorRelation = GetRelation(x => x.SourceId == relation.TargetId && x.TargetId == relation.SourceId);

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Relations.Remove(relation);

                    context.Relations.Remove(mirrorRelation);

                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return false;
                }
            }

            return true;
        }

        public void UpdateRelation(Relation relation)
        {
            Relation oldRelation = GetRelation(relation.Id);

            Relation mirrorRelation = GetRelation(x=>x.SourceId==oldRelation.TargetId 
                                        && x.TargetId == oldRelation.SourceId);

            RelationName relationName = context.RelationNames.Where(x => x.Id == relation.RelationNameId).FirstOrDefault();

            RelationName mirror = context.RelationNames.Where(x=>x.Name == relationName.MirrorName).FirstOrDefault();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    oldRelation.RelationNameId = relation.RelationNameId;

                    mirrorRelation.RelationNameId = mirror.Id;

                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public void AddRelation(Relation relation)
        {
            RelationName relationName = context.RelationNames.Where(x => x.Id == relation.RelationNameId).FirstOrDefault();

            RelationName mirror = context.RelationNames.Where(x => x.Name == relationName.MirrorName).FirstOrDefault();

            Relation mirrorRelation = new Relation() {SourceId = relation.TargetId, TargetId = relation.SourceId, RelationNameId = mirror.Id };

            relation.TargetPerson = null;

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Relations.Add(relation);

                    context.Relations.Add(mirrorRelation);

                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
