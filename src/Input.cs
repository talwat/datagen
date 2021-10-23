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
    }
}