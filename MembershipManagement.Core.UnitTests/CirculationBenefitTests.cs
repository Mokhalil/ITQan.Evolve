using System;
using MembershipManagement.Core.Exceptions;
using MembershipManagement.Core.Model;
using MembershipManagement.Core.Model.Benefits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MembershipManagement.Core.UnitTests
{
    [TestClass]
    public class CirculationBenefitTests
    {
        [TestMethod]
        public void Build_SupplyAllParatmeterCorrect_ReturnsValidCirculatinBenefit()
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
            //Assert
            Assert.AreEqual(membershipId, benefit.MembershipTypeId);
            Assert.AreEqual(borrowPeriod, benefit.BorrowPeriod);
            Assert.AreEqual(noOfNrewals, benefit.NumberOfRenewals);
            Assert.AreEqual(lockingPeriod, benefit.LockingPeriod);
            Assert.AreEqual(renewalPeriod, benefit.RenewalPeriod);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBenefitException))]
        public void Build_NothingAssigned_ThrowInvalidBenefitException()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 10;
            var lockingPeriod = 15;

            //Act
            var builder = BenefitBuilderFactory.CreateBenefitBuilder(BenefitType.Circulation) as CirculationBuilder;
            Circulation benefit = builder
                .ForCirculationType(CirculationType.Book)
                .Build() as Circulation;
            //Assert
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidBenefitException))]
        public void Build_DontAssignBenefitToMembershipType_ThrowInvalidBenefitException()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 10;
            var lockingPeriod = 15;

            //Act
            Circulation benefit = (Circulation)CirculationBuilder.Circulation()
                //.ForMembershipType(membershipId)
                .CirculationsCanBeBorrowedFor(borrowPeriod)
                .CanBeRenewed(noOfNrewals)
                .EachRenewalIs(renewalPeriod)
                .ThenLockedFor(lockingPeriod)
                .Build();
            //Assert
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidBenefitException))]
        public void Build_CirculationPeriodIsZero_ThrowInvalidBenefitException()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 10;
            var lockingPeriod = 15;

            //Act
            Circulation benefit = (Circulation)CirculationBuilder.Circulation()
                .ForMembershipType(membershipId)
                //.CirculationsCanBeBorrowedFor(borrowPeriod)
                .CanBeRenewed(noOfNrewals)
                .EachRenewalIs(renewalPeriod)
                .ThenLockedFor(lockingPeriod)
                .Build();
            //Assert
        }




        [TestMethod]
        [ExpectedException(typeof(InvalidBenefitException))]
        public void Build_RenewalPeriodIsZero_ThrowInvalidBenefitException()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 10;
            var lockingPeriod = 15;

            //Act
            Circulation benefit = (Circulation)CirculationBuilder.Circulation()
                .ForMembershipType(membershipId)
                .CirculationsCanBeBorrowedFor(borrowPeriod)
                .CanBeRenewed(noOfNrewals)
                //.EachRenewalIs(renewalPeriod)
                .ThenLockedFor(lockingPeriod)
                .Build();
            //Assert
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidBenefitException))]
        public void Build_RenewalPeriodIsGreaterThanBorrowPeriod_ThrowInvalidBenefitException()
        {
            //Arrange
            var membershipId = Guid.NewGuid();
            var borrowPeriod = 15;
            var noOfNrewals = 2;
            var renewalPeriod = 16;
            var lockingPeriod = 15;

            //Act
            Circulation benefit = (Circulation)CirculationBuilder.Circulation()
                .ForMembershipType(membershipId)
                .CirculationsCanBeBorrowedFor(borrowPeriod)
                .CanBeRenewed(noOfNrewals)
                .EachRenewalIs(renewalPeriod)
                .ThenLockedFor(lockingPeriod)
                .Build();
            //Assert
        }



    }
}
