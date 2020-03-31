using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC200_RockPaperScissors
{
    // SOLID
    // S - SRP - Single Responsibility Principle 
    //      An object should have only one purpose
    // O - OCP - Open Closed Principle
    //      And object should be open for extension, closed for modification
    // L - Liskov Substitution Principle
    class Player
    {
        // 
    }

    class Hand
    {
        // data fields
        private readonly string _value;

        // constructor
        public Hand(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return this._value; }
        }

        public int CompareTo(Hand other)
        {
            // returns -1 when this hand is less then other (this hand loses)
            // returns 0 when this hand is equal to other   (this hand ties)
            // return 1 when this hand is great then other  (this hand wins)

            if (this.Value == other.Value)
                return 0;

            if (this.Value == "rock")
            {
                if (other.Value == "scissors")
                {
                    return 1; // rock crushes scissors
                }
                else if (other.Value == "spock")
                {
                    return -1; // spock vaporizes rock
                }
                else if (other.Value == "lizard")
                {
                    return 1; // rock crushes lizard
                }
                else if (other.Value == "paper")
                {
                    return -1; // paper covers rock
                }
            }

            if (this.Value == "paper")
            {
                if (other.Value == "rock")
                {
                    return 1; // paper covers rock
                }
                else if (other.Value == "spock")
                {
                    return 1; // paper disproves spock
                }
                else if (other.Value == "lizard")
                {
                    return -1; // paper gets ate by lizard
                }
                else if (other.Value == "scissors")
                {
                    return -1; // paper gets cut scissors
                }
            }

            if (this.Value == "scissors")
            {
                if (other.Value == "paper")
                {
                    return 1;
                }
                else if (other.Value == "spock")
                {
                    return -1; // scissors smashed by spock
                }
                else if (other.Value == "lizard")
                {
                    return 1; // scissors decapitates lizard
                }
                else if (other.Value == "rock")
                {
                    return -1; // 
                }
            }

            if (this.Value == "spock")
            {
                if (other.Value == "paper")
                {
                    return -1;
                }
                else if (other.Value == "scissors")
                {
                    return 1;
                }
                else if (other.Value == "lizard")
                {
                    return -1;
                }
                else if (other.Value == "rock")
                {
                    return 1; // 
                }
            }

            if (this.Value == "lizard")
            {
                if (other.Value == "paper")
                {
                    return 1;
                }
                else if (other.Value == "scissors")
                {
                    return -1;
                }
                else if (other.Value == "spock")
                {
                    return 1;
                }
                else if (other.Value == "rock")
                {
                    return -1; // 
                }
            }

            return 0;
        }
    }

    class GameManager
    {
        // data fields

        // constructor
        public GameManager()
        {

        }

        private Hand GetUserHand()
        {
            bool valid = false;
            Hand result = new Hand("");

            while (valid == false)
            {
                Console.WriteLine("Choose R:Rock, P:Paper, S:Scissors, V:Spock, or L:Lizard (Q to Quit).");
                string userChoice = Console.ReadLine();

                // user could enter an empty line
                if (string.IsNullOrEmpty(userChoice))
                    continue;

                // user could enter an invalid value
                switch (userChoice.ToUpper())
                {
                    case "ROCK":
                    case "R":
                        result = new Hand("rock");
                        valid = true;
                        break;
                    case "PAPER":
                    case "P":
                        result = new Hand("paper");
                        valid = true;
                        break;
                    case "SCISSORS":
                    case "S":
                        result = new Hand("scissors");
                        valid = true;
                        break;
                    case "SPOCK":
                    case "V":
                        result = new Hand("spock");
                        valid = true;
                        break;
                    case "LIZARD":
                    case "L":
                        result = new Hand("lizard");
                        valid = true;
                        break;
                    case "QUIT":
                    case "Q":
                        result = new Hand("quit");
                        valid = true;
                        break;
                }

                Console.Clear();
            }

            return result;
        }

        private Hand GenerateRandomHand()
        {
            // 1 = rock, 2 = paper, 3 = scissors, 4 = spock, 5 = lizard
            Random random = new Random();
            int value = random.Next(1, 5);
            Hand result;

            if (value == 1)
            {
                result = new Hand("rock");
            }
            else if (value == 2)
            {
                result = new Hand("paper");
            }
            else if (value == 3)
            {
                result = new Hand("scissors");
            }
            else if (value == 4)
            {
                result = new Hand("spock");
            }
            else if (value == 5)
            {
                result = new Hand("lizard");
            }
            else
            {
                result = new Hand(string.Empty);
            }

            return result;
        }

        // methods
        public void StartPlay()
        {
            // get the hand from the user
            Hand userHand = GetUserHand();
            while (userHand.Value != "quit")
            {
                // get a hand for the computer
                Hand computerHand = GenerateRandomHand();

                if (computerHand.CompareTo(userHand) < 0)
                {
                    Console.WriteLine("The player chose {0} and computer chose {1}, player wins!", userHand.Value, computerHand.Value);
                }
                else if (computerHand.CompareTo(userHand) > 0)
                {
                    Console.WriteLine("The player chose {0} and computer chose {1}, player loses!", userHand.Value, computerHand.Value);
                }
                else
                {
                    Console.WriteLine("The computer and you chose {0}, its a tie!", computerHand.Value);
                }

                Console.WriteLine();

                // get the hand from the user
                userHand = GetUserHand();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();

            manager.StartPlay();

            Console.ReadLine();
        }
    }
}
