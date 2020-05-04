using System;
using System.Collections.Generic;

namespace prak_4
{
    class BetHistory
    {
        private List<string> History = new List<string>();
        public BetHistory(Player player)
        {
            History.Add(player.InfoPlayer()+"\n");
        }
        public void AddBet(Player player)
        {
            string choice = "";
            if (player.Choice == 'Ч')
                choice = "четное";
            else if (player.Choice == 'Н')
                choice = "нечетное";
            string note = $"Ставка: {player.Bet}$\n" +
                $"Игрок поставил на {choice}\n" +
                $"Баланс игрока после ставки: {player.Balance}\n\n";
            History.Add(note);
        }
        public void PrintHistory(Player player)
        {
            foreach (string note in History)
                Console.Write(note);
        }
    }
}
