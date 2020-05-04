using System;

namespace prak_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите имя игрока: ");
                string name = Console.ReadLine();
                Console.Write("Введите начальный баланс: ");
                int bal = int.Parse(Console.ReadLine());
                if (bal <= 0)
                    throw new Exception();

                Player player = new Player(name, bal);
                BetHistory betHistory = new BetHistory(player);
                int result;

                do
                {
                    result = player.Game();
                    if (result == -1)
                        Console.WriteLine("Неверно введенные данные");
                    if (result != 0 && result != -1)
                        betHistory.AddBet(player);

                } while (result != 0);

                Console.Clear();
                Console.WriteLine("Хотите ли вы посмотреть историю ставок?");
                char choiceH = char.Parse(Console.ReadLine());
                if (choiceH == 'Д' || choiceH == '1')
                {
                    Console.Clear();
                    betHistory.PrintHistory(player);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
