using System;

namespace CSharpPiggyBankConsole
{

    public delegate void MyEventHandler(decimal aVal);

    class PiggyBank
    {

        private decimal _val;
        public event MyEventHandler valueChanged;

        public decimal Val
        {
            get { return _val; }

            set
            {
                _val = value;
                valueChanged(_val);
            }
        }
    } // End class PiggyBank

    class ValueLogger
    {
        public void ValueUpdated(decimal _val)
        {
            Console.WriteLine("The value changed by {0}", _val);
        }
    }//End class ValueLogger

    class SavingGoal
    {
        public void TargetReached(decimal _val)
        {
            if (_val > 500)
            {
                Console.WriteLine("You have reached your goal {0}", _val);
            }
        }
    }//End class SavingsGoal

    class Program
    {

        public static void Main(string[] ags)
        {

            PiggyBank pb = new PiggyBank();
            ValueLogger vl = new ValueLogger();
            SavingGoal sg = new SavingGoal();
            pb.valueChanged += vl.ValueUpdated;
            pb.valueChanged += sg.TargetReached;

            string str;
            decimal amount;

            do
            {
                Console.WriteLine("How much money do you want to add: ");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    amount = decimal.Parse(str);
                    pb.Val += amount;
                }
            } while (!str.Equals("exit"));

        }
    }
}