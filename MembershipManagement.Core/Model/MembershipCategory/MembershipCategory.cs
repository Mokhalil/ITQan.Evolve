using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MembershipManagement.Core.Model;
using MembershipManagement.Core.Model.Benefits;
using MembershipManagement.Core.Model.MembershipCategory.Specifications;
using SharedKernal.Infrastructure.Domain;

namespace MembershipManagement.Core
{
    public class MembershipCategory : Entity<Guid>, AggregateRoot
    {
        private MembershipCategoryBenefitsAreValidSpecification _categoryBenefitsAreValid;
        private List<Benefit> _benefits = new List<Benefit>(); 

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Benefit> Benefits
        {
            get { return _benefits; }
            set
            {
            }
        }

        protected MembershipCategory(Guid id)
            : base(id)
        {
            _categoryBenefitsAreValid = new MembershipCategoryBenefitsAreValidSpecification();
        }

        protected override void Validate()
        {
            if (!_categoryBenefitsAreValid.IsSatisfiedBy(this))
                throw new Exception();
        }

        public void NewBenefit( Benefit benefit)
        {
            Benefits.Add(benefit);
            if (!_categoryBenefitsAreValid.IsSatisfiedBy(this))
            {
                Benefits.Remove(benefit);
               
            }
        }

        public void RemoveBenefit()
        {
        }

        public void UpdateBenefit()
        {
        }

        public void ClearAllBenefits()
        {
        }

        public static MembershipCategory Create(string name, string description, params Benefit[] benefits)
        {
            var category = default(MembershipCategory);

            if ( string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if ( string.IsNullOrEmpty(description))
                throw new Exception("description");

            category = new MembershipCategory(Guid.NewGuid())
            {
                Name = name,
                Description = description
            };

            if ( benefits.Any())
                category.Benefits.AddRange(benefits);

            return category;
        }
    }
}
