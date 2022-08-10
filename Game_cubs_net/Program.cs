using System;

namespace Game_cubs
{
    internal class Program
    {
        const int x = 6; //Размер поля
        const int y = 6;
        const string player1Str = "O ";//Метка игрока 1
        const string player2Str = "X ";//Метка игрока 2
        const string fieldStr = "# ";//Метка пустого поля
        static int[,] Pole = new int[x, y];
        static int round = 0;
        const int maxvin = x * y;
        static int polewin = 0;
        static int player1win = 0;
        static int player2win = 0;

        static void Main(string[] args)
        {
            bool win = true;
            Random random = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Pole[i, j] = 0;
                }
            }


            do
            {
                int x = random.Next(1, 7), y = random.Next(1, 7);
                InterfaceMove(round % 2 + 1, x, y);
                Console.ReadKey();
                round++;
                if (polewin == 0)
                {
                    Console.Clear();
                    PoleOut();
                    if (player1win > player2win)
                        Console.WriteLine("Выйграл 1 игрок");
                    else
                        Console.WriteLine("Выйграл 2 игрок");
                    win = false;

                }
            } while (win);
            Console.WriteLine("игра закончилась");
            Console.ReadKey();
        }
        static void PoleOut()
        {
            player1win = 0;
            player2win = 0;
            polewin = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Pole[i, j] == 0)
                    {
                        Console.Write(fieldStr);
                        polewin++;
                    }
                    else if (Pole[i, j] == 1)
                    {
                        Console.Write(player1Str);
                        player1win++;
                    }
                    else if (Pole[i, j] == 2)
                    {
                        Console.Write(player2Str);
                        player2win++;
                    }
                }
                Console.WriteLine();
            }
        }

        static void InterfaceMove(int player, int rx, int ry)
        {
            int x1, y1;
            Console.Clear();

            PoleOut();
            Console.WriteLine("Игрок: " + player);
            Console.WriteLine("Вам выпало: " + rx + ", и " + ry);
            if (round == 0 || round == 1) { x1 = 0; y1 = 0; }
            else
            {
                Console.WriteLine("Выберите позицию: ");
                do
                {
                    Console.Write("x(Вертикально): ");
                    while (!int.TryParse(Console.ReadLine(), out x1))
                    {
                        Console.Write("Введено не число! x(Вертикально): ");
                    }
                    Console.Write("y(Горизантально): ");
                    while (!int.TryParse(Console.ReadLine(), out y1))
                    {
                        Console.Write("Введено не число! y(Горизантально): ");
                    }
                } while (CheckPole(player, x1, y1));
            }

            Console.WriteLine();
            try
            {
                if (player == 1)
                    for (int i = x1; i < x1 + rx; i++)
                    {
                        for (int j = y1; j < y1 + ry; j++)
                        {
                            if (Pole[i, j] == 0) Pole[i, j] = player;
                        }
                    }
                else if (player == 2)
                    for (int i = x1; i < x1 + rx; i++)
                    {
                        for (int j = y1; j < y1 + ry; j++)
                        {
                            if (Pole[x - 1 - i, y - 1 - j] == 0) Pole[x - 1 - i, y - 1 - j] = player;
                        }
                    }
            }
            catch { }
        }
        static bool CheckPole(int player, int rx, int ry)
        {
            try
            {
                if (player == 1)
                {
                    if (Pole[rx, ry] == player) return false;
                    if (Pole[rx + 1, ry] == player) return false;
                    if (Pole[rx, ry + 1] == player) return false;
                    if (Pole[rx - 1, ry] == player) return false;
                    if (Pole[rx, ry - 1] == player) return false;
                }
                else
                {
                    if (Pole[x - 1 - rx, y - 1 - ry] == player) return false;
                    if (Pole[x - 1 - rx + 1, y - 1 - ry] == player) return false;
                    if (Pole[x - 1 - rx, y - 1 - ry + 1] == player) return false;
                    if (Pole[x - 1 - rx - 1, y - 1 - ry] == player) return false;
                    if (Pole[x - 1 - rx, y - 1 - ry - 1] == player) return false;
                }
            }
            catch
            {
                Console.WriteLine("За пределами массива!");
            }
            Console.WriteLine("Позиция не прилигает к вашей территории");
            return true;
        }
    }
}