namespace HILO
{
    class Program
    {
        //Version of Hi-Lo in Main for Multiplayer
        static void Main(string[] args)
        {
            //Rules of the Game
            Console.WriteLine("Welcome to Hi-Lo Game!\r\n");
            Console.WriteLine("Here are the rules of the Game:");
            Console.WriteLine("1. The goal of the game is to guess the Mystery Number.");
            Console.WriteLine("2. If the player's proposal is not the mystery number then ");
            Console.WriteLine("  a. HI: the mystery number is > the player's guess");
            Console.WriteLine("  b. LO: the mystery number is < the player's guess\r\n");
            Console.WriteLine("Good Luck and Have Fun\r\n");

            int nPlayer = 0;
            bool validInput = false;
            bool inPlay = true;
            string response;
            List<PlayerInfo> list; 

            while (inPlay)
            {
                while (!validInput) //Value between 1 and 4 must be inserted
                {
                    Console.WriteLine("Please insert the Number of Players (between 1 and 4):");

                    try
                    {
                        nPlayer = Convert.ToInt32(Console.ReadLine());
                        if (1 <= nPlayer && nPlayer <= 4)
                            validInput = true;
                        else
                            Console.WriteLine("Invalid Number of Players!");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input");
                        validInput = false;
                    }
                }

                list = new List<PlayerInfo>();
                int min = 1;
                int max = 100;
                Random r = new Random();


                for (int i = 1; i <= nPlayer; i++)
                {
                    list.Add(new PlayerInfo { Name = i.ToString(), MysteryNumber = r.Next(min, max + 1) });
                }

                int playersWin = 0;

                while (playersWin != nPlayer)
                {

                    int userNumber = 0;
                    foreach (PlayerInfo player in list)
                    {
                        validInput = false;
                        if (!player.Success)
                        {
                            while (!validInput)
                            {
                                Console.WriteLine($"Player {player.Name}, Try to Guess the Mystery Number between {min} - {max}: ");

                                try
                                {
                                    userNumber = Convert.ToInt32(Console.ReadLine());
                                    validInput = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid Input");
                                    validInput = false;
                                }
                            }
                            if (validInput)
                            {
                                Console.WriteLine($"Player {player.Name}, Guess: {userNumber}");
                                player.TryNumber++;

                                if (player.MysteryNumber > userNumber)
                                {
                                    Console.WriteLine($"HI");
                                }
                                else if (player.MysteryNumber < userNumber)
                                {
                                    Console.WriteLine($"LO");
                                }
                                else
                                {
                                    playersWin++;
                                    player.Success = true;
                                    player.FinishOrder = playersWin;

                                    Console.WriteLine($"Player {player.Name}, Mystery Number: {userNumber}");
                                    if (playersWin == 1)
                                    {
                                        Console.WriteLine("YOU WIN!");
                                        Console.WriteLine($"Player {player.Name}, Number of Tries {player.TryNumber}\r\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("YOU Guessed the Number!");
                                        Console.WriteLine($"Player {player.Name}, Number of Tries {player.TryNumber}\r\n");
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Summary of the Game");

                foreach (PlayerInfo player in list)
                {
                    Console.WriteLine($"Player {player.Name} Classification: {player.FinishOrder}");
                    Console.WriteLine($"Mystery Number: {player.MysteryNumber}");
                    Console.WriteLine($"Number of Tries to guess: {player.TryNumber}");
                }
                validInput = true;
                while (validInput)
                {
                    Console.WriteLine("Would you like to play again (Y/N)?");
                    response = Console.ReadLine();
                    response = response.ToUpper();

                    if (response.ToUpper() == "Y")
                    {
                        inPlay = true;
                        validInput = false;
                        Console.WriteLine("");
                    }
                    else if (response.ToUpper() == "N")
                    {
                        inPlay = false;
                        validInput = false;
                        Console.WriteLine("");
                    }
                }
            }
            Console.WriteLine("Thank you for playing HiLo!");
            Console.ReadKey();

        }
    }

    class HiloTypes
    {
        //Single Player Version
        public static void SinglePlayer()
        {
            Random r = new Random();

            bool newGame = true;
            int min = 1;
            int max = 100;
            int userNumber;
            int nTries;
            int mysteryNumber;
            string response;

            Console.WriteLine("Welcome to Hi-Lo Game!\r\n");
            Console.WriteLine("Here are the rules of the Game:");
            Console.WriteLine("1. The goal of the game is to guess the Mystery Number.");
            Console.WriteLine("2. If the player's proposal is not the mystery number then ");
            Console.WriteLine("  a. HI: the mystery number is > the player's guess");
            Console.WriteLine("  b. LO: the mystery number is < the player's guess\r\n");
            Console.WriteLine("Good Luck and Have Fun\r\n");

            while (newGame)
            {
                userNumber = 0;
                nTries = 0;
                mysteryNumber = r.Next(min, max + 1);
                response = "";

                while (userNumber != mysteryNumber)
                {
                    Console.WriteLine($"Try to Guess the Mystery Number between {min} - {max}: ");
                    bool validInput = false;
                    try
                    {
                        userNumber = Convert.ToInt32(Console.ReadLine());
                        validInput = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input");
                        validInput = false;
                    }
                    if (validInput)
                    {
                        Console.WriteLine($"Guess: {userNumber}");

                        if (mysteryNumber > userNumber)
                        {
                            Console.WriteLine($"HI");
                        }
                        else if (mysteryNumber < userNumber)
                        {
                            Console.WriteLine($"LO");
                        }
                        nTries++;
                    }
                }
                Console.WriteLine($"Mystery Number: {userNumber}");
                Console.WriteLine("YOU WIN!");
                Console.WriteLine($"Number of Tries {nTries}");

                bool waitInput = true;
                while (waitInput)
                {
                    Console.WriteLine("Would you like to play again (Y/N)?");
                    response = Console.ReadLine();
                    response = response.ToUpper();

                    if (response.ToUpper() == "Y")
                    {
                        newGame = true;
                        waitInput = false;
                        Console.WriteLine("");
                    }
                    else if (response.ToUpper() == "N")
                    {
                        newGame = false;
                        waitInput = false;
                        Console.WriteLine("");
                    }
                }
            }

            Console.WriteLine("Thank you for playing HiLo!");
            Console.ReadKey();
        }
    }

    public class PlayerInfo
    {
        public string Name { get; set; } //Number of the Player
        public int MysteryNumber { get; set; } //Mystery Number for this player to guess
        public int TryNumber { get; set; } //Try Number
        public bool Success { get; set; } //If player has guessed the Number
        public int FinishOrder { get; set; } //Finishing Order

        public PlayerInfo()
        {
            Name = String.Empty;
            MysteryNumber = 0;
            TryNumber = 0;
            Success = false;
            FinishOrder = 0;
        }

    }

}