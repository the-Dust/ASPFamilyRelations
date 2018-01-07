using DataAccess.Entities;
using Services.BuisnessLogic.Base;
using System.Linq;
using System.Web.Mvc;

namespace ASPFamilyRelations.Controllers
{
    public class RelationController : Controller
    {
        IRelationService relationService = null;
        IRelationNameService relationNameService = null;
        IPersonService personService = null;

        public RelationController(IRelationService relationService, 
            IRelationNameService relationNameService, IPersonService personService)
        {
            this.relationService = relationService;
            this.relationNameService = relationNameService;
            this.personService = personService;
        }

        // GET: Relation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RemoveRelation(int id)
        {
            bool removed = relationService.RemoveRelation(id);

            return Json(new { IsRemoved = removed }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Edit(int id, int sourceId=0)
        {
            ViewBag.SourceId = sourceId;

            return PartialView("Modal/_Edit", id);
        }

        public PartialViewResult GetRelation(int id)
        {
            var relation = relationService.GetRelation(id);

            ViewBag.Person = personService.GetPerson(relation.SourceId).ToString();

            ViewBag.RelationNames = relationNameService.GetRelationNames().Select(x => x.Name).ToArray();

            return PartialView("Modal/_RelationPartial", relation);
        }

        public PartialViewResult NewRelation(int sourceId)
        {
            Relation relation = new Relation() { SourceId = sourceId };

            ViewBag.Person = personService.GetPerson(sourceId).ToString();

            ViewBag.RelationNames = relationNameService.GetRelationNames().Select(x => x.Name).ToArray();

            ViewBag.Persons = personService.GetPersons(x=>x.Id!= sourceId).ToArray();

            return PartialView("Modal/_NewRelationPartial", relation);
        }

        [HttpPost]
        public ActionResult UpdateRelation(Relation relation)
        {
            ViewBag.Person = personService.GetPerson(relation.SourceId).ToString();

            ViewBag.RelationNames = relationNameService.GetRelationNames().Select(x => x.Name).ToArray();

            if (relation.Id == 0)
            {
                relationService.AddRelation(relation);
            }

            else
            {
                relationService.UpdateRelation(relation);
            }

            ViewBag.Message = "Изменения родства были сохранены";

            relation.TargetPerson = personService.GetPerson(relation.TargetId);

            return PartialView("Modal/_RelationPartial", relation);
        }

        [HttpPost]
        public ActionResult AddRelation([Bind(Exclude = "Id")]Relation relation)
        {
            return UpdateRelation(relation);
        }
    }
}