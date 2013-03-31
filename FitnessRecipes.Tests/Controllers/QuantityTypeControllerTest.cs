using System.Web.Mvc;
using AutoMapper;
using FitnessRecipes.Controllers;
using FitnessRecipes.DAL.Fakes;
using FitnessRecipes.DAL.Interfaces;
using FitnessRecipes.DAL.Models;
using FitnessRecipes.Models;
using FitnessRecipes.Resources.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

using FitnessRecipes.BLL.MagicStrings;namespace FitnessRecipes.Tests.Controllers
{
    [TestClass]
    public class QuantityTypeControllerTest
    {
        private QuantityTypeController _controller;
        private IQuantityTypeRepository _quantityTypeRepository;
        private IRepositoryManager<QuantityType> _repositoryManager;
            
        [TestInitialize]
        public void TestStartup()
        {
            MapperConfig.ConfigureMapper();
            _quantityTypeRepository = new FakeQuantityTypeRepository();
            _repositoryManager = new FakeQuantityTypeRepositoryManager();
            _controller = new QuantityTypeController(_repositoryManager, _quantityTypeRepository);
            var quantityType = new QuantityType {Name = "ts"};
            _quantityTypeRepository.Create(quantityType);
        }

        [TestMethod]
        [TestCategory(GeneralValues.Controller)]
        public void ShouldGetAllQuantityTypes()
        {
            var result = _controller.Index() as ViewResult;
            result.ShouldNotBeNull();
        }

        [TestMethod]
        [TestCategory(GeneralValues.Controller)]
        public void CreateShouldExist()
        {
            var result = _controller.Create() as ViewResult;
            result.ShouldNotBeNull();
        }
    }
}
