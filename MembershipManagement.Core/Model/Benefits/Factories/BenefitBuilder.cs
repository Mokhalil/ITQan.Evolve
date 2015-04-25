namespace MembershipManagement.Core.Model.Benefits
{
    public abstract class BenefitBuilder
    {
        //Todo : seems like a code smell. 
        protected Benefit Benefit;
        public abstract Benefit Build();
    }
}