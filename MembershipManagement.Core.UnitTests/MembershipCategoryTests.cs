using System;
using MembershipManagement.Core.Model;
using MembershipManagement.Core.Model.Benefits;
using MembershipManagement.Core.Model.MembershipCategory.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MembershipManagement.Core.Model.MembershipCategory.Exceptions;

namespace MembershipManagement.Core.UnitTests
{
    [TestClass]
    public class MembershipCategoryTests
    {
        private MembershipCategory _category = default(MembershipCategory);


        [TestMethod]
        public void CategoryNewInstance_ValidNameAndDescription_ThrowsException()
        {
            //arrange
            var name = Guid.NewGuid().ToString();
            var description = Guid.NewGuid().ToString();

            //Act
            _category = MembershipCategory.Create(name, description);

            //Assert
            Assert.IsInstanceOfType(_category, typeof(MembershipCategory));
            Assert.AreEqual(name, _category.Name);
            Assert.AreEqual(description, _category.Description);

        }

        [TestMethod]
        [ExpectedException(typeof(MembershipCategoryNameIsNotUniqueException))]
        public void CategoryNewInstance_EmptyName_ThrowsException()
        {
           //arrange
            var name = default(string);
            var description = Guid.NewGuid().ToString();
           
            //Act
            _category = MembershipCategory.Create(name, description);
            _category.SetCategoryName

        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 10;
            var lockingPeriod = 15;

            //Act
            Circulation benefit = (Circulation)CirculationBuilder.Circulation()
                  .ForCirculationType(CirculationType.Book)
                .ForMembershipType(membershipId)
                .CirculationsCanBeBorrowedFor(borrowPeriod)
                .CanBeRenewed(noOfNrewals)
                .EachRenewalIs(renewalPeriod)
                .ThenLockedFor(lockingPeriod)
                .Build();

            Circulation benefit2 = (Circulation)CirculationBuilder.Circulation()
                 .ForCirculationType(CirculationType.Book)
               .ForMembershipType(membershipId)
               .CirculationsCanBeBorrowedFor(borrowPeriod)
               .CanBeRenewed(noOfNrewals)
               .EachRenewalIs(renewalPeriod)
               .ThenLockedFor(lockingPeriod)
               .Build();

            
            var category = MembershipCategory.Create("Category1", "Description", benefit, benefit2);
            category.IsValid();


        }
    }
}
