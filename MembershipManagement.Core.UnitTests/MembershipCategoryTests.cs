using System;
using MembershipManagement.Core.Model;
using MembershipManagement.Core.Model.Benefits;
using MembershipManagement.Core.Model.MembershipCategory.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MembershipManagement.Core.UnitTests
{
    [TestClass]
    public class MembershipCategoryTests
    {
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
