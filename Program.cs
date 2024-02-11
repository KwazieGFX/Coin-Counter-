using System;
using System.Runtime.InteropServices.ComTypes;
using static CoinCounter.Program;

namespace CoinCounter
{

    class Program
    {
        public static string input;

        public enum Dollars
        {
            Hundred = 100,
            Twenty = 20,
            Ten = 10,
            Five = 5,
            One = 1,
        }

        public enum Coins
        {
            Quarter = 25,
            Dime = 10,
            Nickel = 5,
            Penny = 1,
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What amount would you like to break down? (dollars and cents in decimal form)");
            input = Console.ReadLine();
            Run(input);
        }

        //get methods to pull currency values from enums
        private static int getHundreds()
        {
            int hundreds = (int)Dollars.Hundred;
            return hundreds;
        }

        private static int getTwenties()
        {
            int twenties = (int)Dollars.Twenty;
            return twenties;
        }

        private static int getTens()
        {
            int tens = (int)Dollars.Ten;
            return tens;
        }

        private static int getFives()
        {
            int fives = (int)Dollars.Five;
            return fives;
        }

        private static int getOnes()
        {
            int ones = (int)Dollars.One;
            return ones;
        }

        /// COINS

        private static int getQuarters()
        {
            int quarters = (int)Coins.Quarter;
            return quarters;
        }

        private static int getDimes()
        {
            int dimes = (int)Coins.Dime;
            return dimes;
        }

        private static int getNickels()
        {
            int nickels = (int)Coins.Nickel;
            return nickels;
        }

        private static int getPennies()
        {
            int pennies = (int)Coins.Penny;
            return pennies;
        }

        static void Run(string Input)
        {


            //Coin Count Variables to be displayed in output
            int QCoins = 0;
            int DCoins = 0;
            int NCoins = 0;
            int PCoins = 0;
            //Bill Count Variables to be displayed in output
            int HBills = 0;
            int TwBills = 0; //Tw = 20 Te = 10
            int TeBills = 0;
            int FBills = 0;
            int OBills = 0;

            //I know this was reddundant but I wanted to practice using enums
            int hundreds = getHundreds();
            int twenties = getTwenties();
            int tens = getTens();
            int fives = getFives();
            int ones = getOnes();

            int quarters = getQuarters();
            int dimes = getDimes();
            int nickels = getNickels();
            int pennies = getPennies();

            ///hopefully this will work :/

            //first im gonna take the input and split it into 2 seperate strings from the '.' before converting them into integers

            string[] totalBillsAndCoins = Input.Split(".");

            int BillAmount = Convert.ToInt32(totalBillsAndCoins[0]);
            int CoinAmount = Convert.ToInt32(totalBillsAndCoins[1]);

            HBills = countUp(hundreds, BillAmount, HBills);
            BillAmount = BillAmount - HBills * 100;
            TwBills = countUp(twenties, BillAmount, TwBills);
            BillAmount = BillAmount - TwBills * 20;
            TeBills = countUp(tens, BillAmount, TeBills);
            BillAmount = BillAmount - TeBills * 10;
            FBills = countUp(fives, BillAmount, FBills);
            BillAmount = BillAmount - FBills * 5;
            OBills = countUp(ones, BillAmount, OBills);
            //Bill Amount should be zero now

            //now for coins
            QCoins = countUp(quarters, CoinAmount, QCoins);
            CoinAmount = CoinAmount - QCoins * 25;
            DCoins = countUp(dimes, CoinAmount, DCoins);
            CoinAmount = CoinAmount - DCoins * 10;
            NCoins = countUp(nickels, CoinAmount, NCoins);
            CoinAmount = CoinAmount - NCoins * 5;
            PCoins = countUp(pennies, CoinAmount, PCoins);


            printResult(HBills, TwBills, TeBills, FBills, OBills, QCoins, DCoins, NCoins, PCoins);

        }

        private static int countUp(int denoms, int total, int BillCoinCount)
        {

            int Dividend = total / denoms;

            while (BillCoinCount < Dividend)
            {
                BillCoinCount++;
            }

            return BillCoinCount;
        }

        public static void printResult(int HUNDREDS, int TWENTIES, int TENS, int FIVES, int ONES, int QUARTERS, int DIMES, int NICKELS, int PENNIES)
        {
            Console.Clear();
            Console.WriteLine($"{input} has {HUNDREDS} hundreds, {TWENTIES} twenties, {TENS} tens, {FIVES} fives, {ONES} ones");
            Console.WriteLine($"{QUARTERS} quarters, {DIMES} dimes, {NICKELS} nickels, and {PENNIES} pennies");
            Console.ReadKey();

        }

    }

}
