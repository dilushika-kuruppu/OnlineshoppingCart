using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.Business.Category;
using OnlineShopping.Common.CategoryDto;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingUnitTest.Business
{
    [TestClass]
    public class CategoryManagerTest
    {
        Mock<IUnitofWork> _mockUnitofWork;
        CategoryManager categoryManager;
        CategoryForDetailDto categoryForDetailDto;
        Mock<ICategoryRepository> _mockCategoryRepository;

        [TestInitialize]
        public void TestInitialize(){
            categoryForDetailDto = new CategoryForDetailDto()
            {
                CategoryId= 1,
                CategoryName = "women"


            };
            _mockUnitofWork = new Mock<IUnitofWork>();
            _mockCategoryRepository = new Mock<ICategoryRepository>();
            _mockCategoryRepository.Setup(x => x.GetCategory()).ReturnsAsync(categoryForDetailDto);
            _mockUnitofWork.Setup(m => m.CategoryRepository).Returns(_mockCategoryRepository.Object);

        }
        [TestMethod]
   
        public void GetCategory_WhenSuccessfull_ReturnGetCategory() {
            categoryManager = new CategoryManager(_mockUnitofWork.Object);
            var category = categoryManager.GetCategory();
            Assert.AreEqual("women", category.Result.CategoryName);
        }
    }
}
