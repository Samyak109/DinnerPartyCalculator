namespace DinnerParty
{
    class DinnerParty : Party
    {
        public bool HealthyOption { get; set; }

        public override decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                totalCost += CalculateCostOfDecorations();

                decimal totalBeverageCost = CalculateCostOfBeveragesPerPerson() * NumberOfPeople;
                totalCost += totalBeverageCost;

                if (HealthyOption)
                {
                    return totalCost * 0.95M;
                }
                return totalCost;
            }
        }

        public DinnerParty(int numberOfPeople, bool healthyOpotion, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            HealthyOption = healthyOpotion;
            FancyDecorations = fancyDecorations;
        }


        private decimal CalculateCostOfBeveragesPerPerson()
        {
            decimal costOfBeveragesPerPerson;
            if (HealthyOption)
            {
                costOfBeveragesPerPerson = 5.00M;
            }
            else
            {
                costOfBeveragesPerPerson = 20.00M;
            }
            return costOfBeveragesPerPerson;
        }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
            {
                costOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                costOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            }
            return costOfDecorations;
        }
    }
}
