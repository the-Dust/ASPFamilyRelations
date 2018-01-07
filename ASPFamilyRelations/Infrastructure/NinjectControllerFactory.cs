using DataAccess.Repositories;
using DataAccess.Repositories.Base;
using Ninject;
using Services.BuisnessLogic;
using Services.BuisnessLogic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPFamilyRelations.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel Kernel { get; private set; }

        public NinjectControllerFactory()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        public void AddBindings()
        {
            Kernel.Bind<IRelationRepository>().To<RelationRepository>();
            Kernel.Bind<IRelationNameRepository>().To<RelationNameRepository>();
            Kernel.Bind<IPersonRepository>().To<PersonRepository>();


            Kernel.Bind<IRelationService>().To<RelationService>();
            Kernel.Bind<IRelationNameService>().To<RelationNameService>();
            Kernel.Bind<IPersonService>().To<PersonService>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType != null ? (IController)Kernel.Get(controllerType) : null;
        }
    }
}