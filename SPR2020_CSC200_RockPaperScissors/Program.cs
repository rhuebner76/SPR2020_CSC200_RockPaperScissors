using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC200_RockPaperScissors
{
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
            // returns -1 when this hand is less then other
            // returns 0 when this hand is equal to other
            // return 1 when this hand is great then other

            if (this.Value == other.Value)
                return 0;

            if (this.Value == "rock")
            {
                if (other.Value == "scissors")
                {
                    return 1;
                }
                else if (other.Value == "paper")
                {
                    return -1;
                }
            }

            if (this.Value == "paper")
            {
                if (other.Value == "rock")
                {
                    return 1;
                }
                else if (other.Value == "scissors")
                {
                    return -1;
                }
            }

            if (this.Value == "scissors")
            {
                if (other.Value == "paper")
                {
                    return 1;
                }
                else if (other.Value == "rock")
                {
                    return -1;
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
                Console.WriteLine("Choose R:Rock, P:Paper, or S:Scissors (Q to Quit).");
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
            // 1 = rock, 2 = paper, 3 = scissors
            Random random = new Random();
            int value = random.Next(1, 3);
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
