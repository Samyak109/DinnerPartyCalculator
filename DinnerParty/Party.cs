namespace DinnerParty
{
    class Party
    {
        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople { get; set; }

        public bool FancyDecorations { get; set; }

        public virtual decimal Cost
        {
            get
            {

                decimal totalCost = 0;
                totalCost += CostOfFoodPerPerson * NumberOfPeople;
                if (NumberOfPeople > 12)
                {
                    totalCost += 100;
                }
                return totalCost;
            }
        }
    }
}
