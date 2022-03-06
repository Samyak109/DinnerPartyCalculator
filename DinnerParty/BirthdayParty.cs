using System.Collections.Generic;

namespace DinnerParty
{
    class BirthdayParty : Party
    {

        public string CakeWriting { get; set; }

        public bool CakeWritingTooLong
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                {
                    return true;
                }
                return false;
            }
        }

        private readonly Dictionary<int, int> sizeWritingLengthMap = new Dictionary<int, int>();

        public BirthdayParty(int numberOfPeople, bool fancyDecorations, string cakeWriting)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            CakeWriting = cakeWriting;
            sizeWritingLengthMap.Add(8, 16);
            sizeWritingLengthMap.Add(16, 40);
        }


        private int ActualLength
        {
            get
            {
                return CakeWriting.Length > MaxWritingLength() ? MaxWritingLength() : CakeWriting.Length;
            }
        }

        private int CakeSize()
        {
            if (NumberOfPeople <= 4)
            {
                return 8;
            }
            return 16;
        }

        private int MaxWritingLength()
        {
            if (CakeSize() == 8)
            {
                return sizeWritingLengthMap[8];
            }
            return sizeWritingLengthMap[16];
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

        public override decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                totalCost += CalculateCostOfDecorations();

                if (CakeSize() == 8)
                {
                    totalCost += 40M + ActualLength * .25M;
                }
                {
                    totalCost += 75M + ActualLength * .25M;
                }
                return totalCost;
            }
        }



    }
}
