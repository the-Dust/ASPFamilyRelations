using DataAccess.Entities;
using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ASPFamilyRelations.Controllers
{
    public class HomeController : Controller
    {
        IRelationService relationService = null;
        IPersonService personService = null;

        public HomeController(IRelationService relationService, IPersonService personService)
        {
            this.relationService = relationService;
            this.personService = personService;
        }

        public ActionResult Index()
        {
            IEnumerable<Person> persons = personService.GetPersons();

            return View(persons);
        }

        public ActionResult ShowFiltered(string surname, string name, string patronymic, 
            string birthDate, string country, string city, string street)
        {
            string[] keywords = { surname, name, patronymic, country, city, street };

            DateTime birth;

            bool hasDate = DateTime.TryParse(birthDate, out birth);

            Expression<Func<Person, bool>> func;

            if (hasDate)
                func = x => x.BirthDate == birth;
            else
                func = x => true;

            IEnumerable<Person> persons = personService.SearchByString(func, keywords);

            return View("Index", persons);
        }

        public ActionResult GetRelations(int id)
        {
            ViewBag.Person = personService.GetPerson(id);

            IEnumerable<Relation> relations = relationService.GetRelations(x=>x.SourceId==id);

            return View(relations);
        }

        public PartialViewResult Edit(int id, bool details = false)
        {
            ViewBag.Details = details;

            return PartialView("Modal/_Edit", id);
        }

        public PartialViewResult GetPerson(int id)
        {
            var person = personService.GetPerson(id);

            return PartialView("Modal/_PersonPartial", person);
        }

        public PartialViewResult GetPersonDetails(int id)
        {
            var person = personService.GetPerson(id);

            return PartialView("Modal/_PersonDetailsPartial", person);
        }

        [HttpPost]
        public ActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.Id == 0)
                {
                    personService.AddPerson(person);
                }

                personService.UpdatePerson(person);

                ViewBag.Message = "Изменения профиля были сохранены";

            }
            return PartialView("Modal/_PersonPartial", person);
        }

        [HttpPost]
        public ActionResult AddPerson([Bind(Exclude = "Id")]Person person)
        {
            return UpdatePerson(person);
        }

        [HttpPost]
        public JsonResult RemovePerson(int id)
        {
            personService.RemovePerson(id);

            return Json(new { IsRemoved = true }, JsonRequestBehavior.AllowGet);
        }
 
    }
}