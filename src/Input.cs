namespace Input {
    class Input {
        public static bool AnswerToBool(string answer) {
            if(
                answer == "yes" 
                || answer == "y" 
                || answer == "yeah" 
                || answer == "yep" 
                || answer == "mhm" 
                || answer == "absolutely"
            )
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static string GetArg() {
            bool stillAsk = true;
            while(stillAsk) {
                string answer;
                answer = System.Console.ReadLine();
                if(!Commands.Commands.OnlyContains(answer, ' ')) {
                    stillAsk = false;
                    return answer;
                }
                else {
                    Logging.Logging.Log("Nothing Inputted\n", "error");
                }
            }
            return "";
        }
    }
}