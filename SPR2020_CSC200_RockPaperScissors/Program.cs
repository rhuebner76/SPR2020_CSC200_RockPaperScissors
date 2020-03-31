using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC200_RockPaperScissors
{
    // SOLID
    // -----
    // S - SRP - Single Responsibility Principle 
    //      An object should have only one purpose
    // O - OCP - Open Closed Principle
    //      And object should be open for extension, closed for modification
    // L - LSP - Liskov Substitution Principle
    //      Any object object inheriting an interface should implement that interface
    // I - ISP - Interface Segregation Principle
    //      An object should expose only what what it needs to and we should code to that interface
    // D - DIP - Dependency Inversion Principle 
    // -------
    // DRY - Don't Repeat Yourself
    // -------

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
    }

    class Rule
    {
        private readonly string _handA;
        private readonly string _handB;
        private readonly int _result;

        // responsibility: given two hands, what it is the outcome
        public Rule(string handA, string handB, int result)
        {
            _handA = handA;
            _handB = handB;
            _result = result;
        }

        // methods
        public bool CanEvaluate(string handA, string handB)
        {
            return _handA == handA && _handB == handB;
        }

        public int Result()
        {
            return _result;
        }
    }

    class GameManager
    {
        // data fields
        private ICollection<Rule> _rules;

        // constructor
        public GameManager(ICollection<Rule> rules)
        {   
            _rules = rules;
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
                int comparison = 0;

                foreach (Rule rule in _rules)
                {
                    if (rule.CanEvaluate(userHand.Value, computerHand.Value))
                    {
                        comparison = rule.Result();
                    }
                }

                if (comparison > 0)
                {
                    Console.WriteLine("The player chose {0} and computer chose {1}, player wins!", userHand.Value, computerHand.Value);
                }
                else if (comparison < 0)
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
            GameManager manager = new GameManager(RockPaperScissorsLizardSpockRules());

            manager.StartPlay();

            Console.ReadLine();
        }

        static ICollection<Rule> RockPaperScissorsRules()
        {
            ICollection<Rule> rules = new List<Rule>();
            rules = new List<Rule>();
            rules.Add(new Rule("rock", "scissors", 1));
            rules.Add(new Rule("rock", "paper", -1));
            rules.Add(new Rule("rock", "rock", 0));
            
            rules.Add(new Rule("paper", "rock", 1));
            rules.Add(new Rule("paper", "scissors", -1));
            rules.Add(new Rule("paper", "paper", 0));
            
            rules.Add(new Rule("scissors", "paper", 1));
            rules.Add(new Rule("scissors", "rock", -1));
            rules.Add(new Rule("scissors", "scissors", 0));

            return rules;
        }

        static ICollection<Rule> RockPaperScissorsLizardSpockRules()
        {
            ICollection<Rule> rules = new List<Rule>();
            rules = new List<Rule>();
            rules.Add(new Rule("rock", "scissors", 1));
            rules.Add(new Rule("rock", "paper", -1));
            rules.Add(new Rule("rock", "rock", 0));
            rules.Add(new Rule("rock", "lizard", 1));
            rules.Add(new Rule("rock", "spock", -1));

            rules.Add(new Rule("paper", "rock", 1));
            rules.Add(new Rule("paper", "scissors", -1));
            rules.Add(new Rule("paper", "paper", 0));
            rules.Add(new Rule("paper", "lizard", -1));
            rules.Add(new Rule("paper", "spock", 1));

            rules.Add(new Rule("scissors", "paper", 1));
            rules.Add(new Rule("scissors", "rock", -1));
            rules.Add(new Rule("scissors", "scissors", 0));
            rules.Add(new Rule("scissors", "lizard", -1));
            rules.Add(new Rule("scissors", "spock", 1));

            rules.Add(new Rule("lizard", "paper", 1));
            rules.Add(new Rule("lizard", "rock", -1));
            rules.Add(new Rule("lizard", "lizard", 0));
            rules.Add(new Rule("lizard", "scissors", -1));
            rules.Add(new Rule("lizard", "spock", 1));

            rules.Add(new Rule("spock", "rock", 1));
            rules.Add(new Rule("spock", "scissors", 1));
            rules.Add(new Rule("spock", "spock", 0));
            rules.Add(new Rule("spock", "paper", -1));
            rules.Add(new Rule("spock", "lizard", -1));

            return rules;
        }
    }
}
