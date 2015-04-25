namespace MembershipManagement.Core.Model.Benefits
{
    public class BenefitBuilderFactory
    {
        public static BenefitBuilder CreateBenefitBuilder(BenefitType type)
        {
            switch (type)
            {
                case BenefitType.Circulation:
                    return CirculationBuilder.Circulation();
                //case BenefitType.Facility:

                //case BenefitType.TimedFacility:
                default :
                    return null;
            }
        }
    }
}