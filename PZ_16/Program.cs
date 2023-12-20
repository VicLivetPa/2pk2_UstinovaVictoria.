using System;
using System.IO;

namespace PZ_16

{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize + 1]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек
        static int playerHealth = 50; //здоровье персонажа
        static int enemyHealth = 30; //здоровье врага
        static int playerDamage = 10; //урон персонажа
        static int enemyDamage = 5; //урон врага
        static int enemiesCount = 10; //подсчёт врагов
        static int steps = 0; //для подсчёта пройденных шагов
        static int oldStep = 0; //для проверки окончания баффа

        static void Main(string[] args)
        {
            StartDisplay();
            Move();
        }

        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    map[i, j] = '.';
                }
            }

            map[playerX, playerY] = 'P'; // в середину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize); //чтобы по правому краю  не поялялись 

                //если ячейка пуста,то добавляется враг
                if (map[x, y] == '.')
                {
                    map[x, y] = 'E';
                    enemies--; // уменьшение количества нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize);

                if (map[x, y] == '.')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize);

                if (map[x, y] == '.')
                {
                    map[x, y] = '+';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли
        }
        /// <summary>
        /// перемещение персонажа
        /// </summary>
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;
            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                StatisticInGame(); //вывод статистики в момент игры
                CheckStepsOfGetBuff(); //проверка оставшихся шагов до окончания действия баффа, если он подобран
                WinGame();
                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    //управление стрелочками на клавиатуре
                    case ConsoleKey.UpArrow:
                        steps++; //подсчёт шагов при каждом движении
                        playerX--;
                        Barrier();
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        steps++;
                        Barrier();
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        steps++;
                        Barrier();
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        steps++;
                        Barrier();
                        break;


                    default:
                        break;
                }


                switch (map[playerX, playerY]) //считывает с чем контактирует игрок
                {
                    case 'E': //если напал на врага
                        Fight();
                        enemiesCount--;
                        break;
                    case '+': //если подобрал аптечку
                        playerHealth = 50;
                        map[playerX, playerY] = '.';
                        break;
                    case 'B': //если подобрал бафф
                        GetBuff();
                        break;
                }

                Console.CursorVisible = false;
                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '.';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('.');

                //обновление положения персонажа
                map[playerX, playerY] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');
            }
        }
        /// <summary>
        /// вывод карты на консоль
        /// </summary>
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {

                    //раскраска и вывод
                    switch (map[i, j])
                    {
                        case '+':
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'B':
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                }
                Console.WriteLine(map[i, 0]);
            }
        }
        //static void Fight()
        //{
        //    while(playerHealth >0 && enemyHealth > 0) { }
        //    enemyHealth -= playerDamage; //отнимание хп у врага

        //    playerHealth -= enemyDamage; //отнимание хп у игрока


        //    if (playerHealth <= 0)//если игрок погиб
        //    {
        //        Death();

        //    }

        //    if (enemiesCount == 0) //если врагов не осталось
        //    {
        //        WinGame();

        //    }

        //}
        static void GetBuff()
        {
            oldStep = steps;
            if (playerDamage < 20)
            {
                playerDamage = playerDamage * 2;
            }
            map[playerX, playerY] = '.';
        }
        static void CheckStepsOfGetBuff()
        {
            if (playerDamage > 10) //если урон уже увеличен
            {
                if ((20 - (steps - oldStep)) % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(mapSize + 12, 22);
                    Console.Write($" До окончания действия баффа осталось шагов: {20 - (steps - oldStep)} ");
                    Console.ResetColor();
                }
                else if (20 - (steps - oldStep) % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(mapSize + 12, 22);
                    Console.Write($" До окончания действия баффа осталось шагов: {20 - (steps - oldStep)} ");
                    Console.ResetColor();
                }

                if (steps - oldStep == 20) //если время действия баффа закончилось
                {
                    playerDamage = 10; // значение дамага игрока
                    Console.SetCursorPosition(mapSize + 12, 22);
                    //заполнение строки о времени действия баффа пустотой
                    Console.Write("                                                              ");
                }
            }
        }
        static void StatisticInGame()
        {
            if (playerHealth <= 15)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(mapSize + 12, 10);
                Console.Write($" Здоровье игрока: {playerHealth}    ");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(mapSize + 12, 10);
                Console.Write($" Здоровье игрока: {playerHealth}    ");
            }
            Console.SetCursorPosition(mapSize + 12, 11);
            Console.Write($" Урон игрока: {playerDamage}     ");
            Console.SetCursorPosition(mapSize + 12, 12);
            Console.Write($" Осталось врагов: {enemiesCount}   ");
            Console.SetCursorPosition(mapSize + 12, 13);
            Console.Write($" Пройдено шагов: {steps}    ");
            Console.SetCursorPosition(mapSize + 12, 5);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("P");
            Console.ResetColor();
            Console.Write(" - ваш персонаж");
            Console.SetCursorPosition(mapSize + 12, 6);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("E");
            Console.ResetColor();
            Console.Write(" - враги");
            Console.SetCursorPosition(mapSize + 12, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");
            Console.ResetColor();
            Console.Write(" - аптечка(восстанавливает здоровье до max)");
            Console.SetCursorPosition(mapSize + 12, 8);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("B");
            Console.ResetColor();
            Console.Write(" - бафф(урон вдвое)");

        }
        static void StartDisplay()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8; //юникод символы
            Console.CursorVisible = false; //скрытный курсов
            Console.SetCursorPosition(30, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(". . . . . . . . . . . . . . . . . . . . . . . . .  ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write(" A - начать новую игру");
            Console.SetCursorPosition(40, 12);
            Console.Write(" D - загрузить сохраненную игру");
            Console.SetCursorPosition(30, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(". . . . . . . . . . . . . . . . . . . . . . . . . ");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D: //запуск последнего сохранения
                    Console.Clear();

                    break;
                case ConsoleKey.A: //запуск новой игры

                    GenerationMap();
                    break;
                default: //если игрок нажимает на другие кнопки 
                    StartDisplay();
                    break;
            }
        }

        static void WinGame()
        {
            if (enemiesCount == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(30, 9);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(". . . . . . . . . . . . . . . . . . . . . ");
                Console.ResetColor();
                Console.SetCursorPosition(30, 10);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Вы победили! ");
                Console.ResetColor();
                Console.SetCursorPosition(30, 11);
                Console.Write($" Количество пройденных шагов: {steps}");
                Console.SetCursorPosition(30, 12);
                Console.Write($" Вернуться на стартовый экран - клавиша K");
                Console.SetCursorPosition(30, 13);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(". . . . . . . . . . . . . . . . . . . . ");
                Console.ResetColor();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.K:
                        StartDisplay();
                        break;
                    default:
                        WinGame();
                        break;
                }
            }
        }
        static void Death()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(". . . . . . . . . . . . . . . . . .");
            Console.ResetColor();
            Console.SetCursorPosition(40, 10);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Вы проиграли...  ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write($" Количество пройденных шагов: {steps}");
            Console.SetCursorPosition(40, 12);
            Console.Write($" Вернуться на стартовый экран - клавиша K");
            Console.SetCursorPosition(40, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(". . . . . . . . . . . . . . . . . . . ");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.K: //если игрок нажал на K
                    StartDisplay();
                    break;
                default:
                    Death();
                    break;
            }
        }

        //БАРЬЕРЫ
        static void Barrier()
        {
            //игрок остаётся на прежнем месте,если координаты игрока выходят за край 
            if (playerX == -1)
            {
                playerX = 0;
                steps--; //  шага фактически нет
            }
            if (playerY == -1)
            {
                playerY = 0;
                steps--;
            }
            if (playerX == mapSize)
            {
                playerX = mapSize - 1;
                steps--;
            }
            if (playerY == mapSize)
            {
                playerY = mapSize - 1;
                steps--;
            }
        }

        //БОЙ
        static void Fight()
        {
            while (playerHealth > 0 && enemyHealth > 0)
            {
                enemyHealth -= playerDamage;
                if (enemyHealth <= 0)
                {

                    map[playerX, playerY] = '.';

                }
                playerHealth -= enemyDamage;
                if (playerHealth <= 0)
                {

                    Death();
                }


            }
            enemyHealth = 30;

        
        }
    }
}
