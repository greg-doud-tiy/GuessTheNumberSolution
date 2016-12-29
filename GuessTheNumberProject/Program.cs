using System;
using System.Collections.Generic;

namespace GuessTheNumberProject {
    class MainClass {
        
        string answer = "GAME OF THRONES";
        string puzzle = string.Empty;
        static int maxTries = 7;
        int remainingTries = maxTries;

        void Run() {
            for (var idx = 0; idx < this.answer.Length; idx++) {
                string ch = this.answer.Substring(idx, 1);
                if(ch.Equals(" ")) {
                    this.puzzle += " ";
                } else {
                    this.puzzle += "?";
                }
            }
            Display(this.puzzle);

            var letter = Ask("Enter a letter: ").ToUpper();
            while(this.remainingTries > 0 && !PuzzleSolved()) {
                Guess(letter);
                Display(puzzle);
                if (!PuzzleSolved()) {
                    letter = Ask("Enter a letter: ").ToUpper();
                }
            }
        }
        bool PuzzleSolved() {
            return !this.puzzle.Contains("?");
        }
        void Guess(string letter) {
            var correctGuess = false;
            for (var idx = 0; idx < this.puzzle.Length; idx++) {
                if (letter == this.answer[idx].ToString()) {
                    correctGuess = true;
                    if (idx == 0) {
                        this.puzzle = letter + this.puzzle.Substring(1);
                    } else {
                        this.puzzle = this.puzzle.Substring(0, idx) + letter + this.puzzle.Substring(idx + 1);
                    }
                } 
            }
            if(!correctGuess) {
                this.remainingTries--;
                Console.WriteLine("{0} tries remaining.", this.remainingTries);
            }
        } 
        void Display(string puzzle) {
            foreach(char ch in puzzle) {
                Console.Write(ch.ToString() + " ");
            }
            Console.WriteLine();
        }
        void Prompt(string message) {
            Console.Write(message);
            Console.Write(" ... press any key");
            Console.ReadKey();
        }
        string Ask(string message) {
            Console.Write(message);
            var response = Console.ReadLine();
            return response;
        }
        public static void Main(string[] args) {
            new MainClass().Run();
        }
    }
}
