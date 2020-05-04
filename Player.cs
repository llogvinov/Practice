using System;

namespace prak_4
{
    class Player
    {
        private string Name { set; get; }
        public int Balance { set; get; }
        public int Bet;
        public char Choice;
        public Player (string name, int balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
        public string InfoPlayer()
        {
            return $"Имя: {Name}\nБаланс: {Balance}\n";
        }
        private bool CheckChoice(char choice)
        {
            if (choice == 'Ч' || choice == 'Н' || choice == '0')
                return true;
            else
                return false;
        }
        private bool CheckBet(int bet)
        {
            if (bet <= this.Balance && bet > 0)
                return true;
            else
                return false ;
        }
        private bool EqualsTo(char choice, int number)
        {
            if (choice == 'Ч' & number == 0 || choice == 'Н' & number == 1)
                return true;
            else 
                return false;
        }
        public int Game() 
        {
            Console.Clear();
            Console.WriteLine($"Текущий баланс игрока: {this.Balance}$\n");

            Random RandomNumber = new Random();
            int Number = RandomNumber.Next(0, 2);

            try
            {
                Console.Write("Выберете на что поставить: ");
                Choice = char.Parse(Console.ReadLine());
                if (!CheckChoice(this.Choice))
                    return -1;
                else if (Choice == '0')
                    return 0;

                Console.Write("Введите сумму ставки: ");
                Bet = int.Parse(Console.ReadLine());
                if (!CheckBet(this.Bet))
                    return -1;

                if (!EqualsTo(Choice, Number))
                {
                    this.Balance -= this.Bet;
                    Console.WriteLine("\nВы не угадали число\nНе расстраивайтесь..");
                    Console.ReadLine();
                    if (Balance == 0)
                        return 0;
                }
                else
                {
                    this.Balance += this.Bet;
                    Console.WriteLine("\nВы угадали число\nПоздравляем!");
                    Console.ReadLine();
                }
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
