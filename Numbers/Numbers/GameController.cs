﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PlayerModel;
using SaveLoader;

namespace Game
{
    static class GameController
    {
        static CurrentPlayer _player1;
        static CurrentPlayer _player2;

        static GameController()
        {
            _player1 = new CurrentPlayer() { PlayerName = "Гость 1" };
            _player2 = new CurrentPlayer() { PlayerName = "Гость 2" };
        }

        public static void MainMenu()
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine($"1.Начать новую игру {_player1.PlayerName}  против {_player2.PlayerName}");
                Console.WriteLine($"2.Загрузить первого игрока \n3.Загрузить второго игрока");
                Console.WriteLine($"4.Создать нового игрока");
                Console.WriteLine($"5.Выход");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            NewGame();
                            break;
                        }
                    case "2":
                        {
                            _player1 = LoadPlayer();
                            break;
                        }
                    case "3":
                        {
                            _player2 = LoadPlayer();
                            break;
                        }
                    case "4":
                        {
                            CreatePlayer();
                            break;
                        }
                    case "5":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Такого пункта нет, выберите корректный пункт меню:");
                            break;
                        }
                }
            } while (input != "5");

        }

        public static void NewGame()
        {
            Console.Clear();
            Console.WriteLine($"Раунд 1:");
            Round(_player1, _player2);
            Round(_player2, _player1);
        }

        static void Round(CurrentPlayer player1, CurrentPlayer player2)
        {
            InputNumbers(player1);
            Console.Clear();
            GuessNumber(player2);
        }

        static void InputNumbers(CurrentPlayer currentPlayer)
        {
            Console.WriteLine($"Игрок {currentPlayer.PlayerName} введите минимальное число, которое Вы можете загадать. Если не ввести, присвоится число 0:");
            currentPlayer.MinNumber = ReadNumberFromConsole();
            Console.WriteLine($"Игрок {currentPlayer.PlayerName} введите максимальное число, которое Вы можете загадать. Если не ввести, присвоится число 0:");
            do
            {
                currentPlayer.MaxNumber = ReadNumberFromConsole();
                if (currentPlayer.MaxNumber <= currentPlayer.MinNumber)
                {
                    Console.WriteLine($"{currentPlayer.PlayerName}, максимальное число должно быть больше {currentPlayer.MinNumber}\n попробуйте еще раз:");
                }
                else
                {
                    break;
                }
            } while (true);
            do
            {
                Console.WriteLine($"Игрок {currentPlayer.PlayerName} введите число, которое Вы загадываете,\nоно должно быть больше или равно {currentPlayer.MinNumber}, и меньше или равно {currentPlayer.MaxNumber}:");
                currentPlayer.SecretNumber = ReadNumberFromConsole();
                if (currentPlayer.SecretNumber >= currentPlayer.MinNumber && currentPlayer.SecretNumber <= currentPlayer.MaxNumber)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.PlayerName}, Вы ввели число, которое за границами допустимого диапазона");
                }
            } while (true);
            currentPlayer.SecretNumber = ReadNumberFromConsole();
        }

        static void GuessNumber(CurrentPlayer currentPlayer)
        {
            Console.WriteLine($"{currentPlayer.PlayerName} вам нужно отгадать число x, которое ");
        }

        //считывает значение int с консоли
        public static int ReadNumberFromConsole()
        {
            ConsoleKeyInfo key;
            var rule = @"[0-9]";
            var sb = new StringBuilder();
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;

                if (Regex.IsMatch(key.KeyChar.ToString(), rule))
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            Console.WriteLine();
            if (sb.Length == 0)
            {
                return 0;
            }
            return int.Parse(sb.ToString());
        }

        //пытается создать нового пользователя, с уникальным именем
        public static void CreatePlayer()
        {
            var player = new PlayerBase();
            var context = new PlayerContext();
            Console.WriteLine("Создание игрока: \n Введите ваше имя:");
            do
            {
                string name = Console.ReadLine();
                Console.WriteLine("проверка существует ли такой игрок...");
                if (context.IsPlayerExist(name))
                {
                    Console.WriteLine("Такой игрок существует, попробуйте придумать другое имя :(");
                }
                else
                {
                    player.PlayerName = name;
                    break;
                }
            } while (true);
            Console.WriteLine($"Игрок {player.PlayerName} не найден, теперь вы {player.PlayerName}");
            Console.WriteLine($"{player.PlayerName} придумайте пароль(если хотите):");
            string password = Console.ReadLine();
            player.PlayerPassword = password;
            player.PlayerScore = 100;
            SaverToDb.SavePlayerToDB(player);
        }

        //пытается загрузить существующего пользователя
        public static CurrentPlayer LoadPlayer()
        {
            string name;
            string pass;
            CurrentPlayer currentPlayer = new CurrentPlayer();
            using (PlayerContext context = new PlayerContext())
            {
                Console.Clear();
                do
                {
                    Console.WriteLine($"Введите имя пользователя, которого необходимо загрузить:");
                    name = Console.ReadLine();
                    if (context.IsPlayerExist(name))
                    {
                        PlayerBase loadedPlayer;
                        Console.WriteLine($"Добро пожаловать {name}, пожалуйста введите ваш пароль:");
                        do
                        {
                            pass = Console.ReadLine();
                            loadedPlayer = LoaderFromDB.LoadPlayer(name, pass);
                            if (loadedPlayer == null)
                            {
                                Console.WriteLine($"{name} пароль не верный, попробуйте еще раз");
                            }
                        } while (loadedPlayer == null);
                        currentPlayer.PlayerName = loadedPlayer.PlayerName;
                        currentPlayer.PlayerPassword = loadedPlayer.PlayerPassword;
                        currentPlayer.PlayerScore = loadedPlayer.PlayerScore;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Такого пользователя не существует, попробуйте еще раз или quit для выхода.");
                    }
                } while (name != "quit");
            }
            return currentPlayer;
        }

    }
}
