using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;

[assembly: WebActivator.PreApplicationStartMethod(typeof(FitnessRecipes.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(FitnessRecipes.App_Start.NinjectWebCommon), "Stop")]

namespace FitnessRecipes.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepository<Ingredient>>().To<Repository<Ingredient>>();
            //kernel.Bind<IRepository<Recipe>>().To<Repository<Recipe>>();
            //kernel.Bind<IRepository<QuantityType>>().To<Repository<QuantityType>>();
            //kernel.Bind<IRepository<Author>>().To<Repository<Author>>();
            //kernel.Bind<IRepository<Category>>().To<Repository<Category>>();
            //kernel.Bind<IRepository<Language>>().To<Repository<Language>>();
            //kernel.Bind<IRepository<Text>>().To<Repository<Text>>();

            //kernel.Bind<IRepository<Ingredient>>().To<FakeRepository<Ingredient>>();
            //kernel.Bind<IRepository<Recipe>>().To<FakeRepository<Recipe>>();
            //kernel.Bind<IRepository<QuantityType>>().To<FakeRepository<QuantityType>>();
            //kernel.Bind<IRepository<Author>>().To<FakeRepository<Author>>();
            //kernel.Bind<IRepository<Category>>().To<FakeRepository<Category>>();
            //kernel.Bind<IRepository<Language>>().To<FakeRepository<Language>>();
            //kernel.Bind<IRepository<Text>>().To<FakeRepository<Text>>();
        }
    }
}
