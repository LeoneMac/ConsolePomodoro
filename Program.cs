namespace Pomodoro
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Do you want to start a new session? (Y/N)");
            ReadInput();
        }

        private static void ReadInput()
        {
            while (true)
            {
                var userInput = Console.ReadKey().KeyChar;
                switch (userInput.ToString().ToUpper())
                {
                    case "y" or "Y":
                        StartTimer(false);
                        break;
                    case "n" or "N":
                        Console.Clear();

                        Console.WriteLine("Ok!");
                        Thread.Sleep(1000);

                        Exit();
                        break;
                    default:
                        Console.WriteLine("Only 'y' or 'n', bro");
                        continue;
                }
                
                break;
            }
        }
        private static void StartTimer(bool isBreak)
        {
            var currentTime = DateTime.Now;
            DateTime endingTime = !isBreak ? currentTime.AddMinutes(20) : currentTime.AddMinutes(5);

            Console.WriteLine("");
            Console.WriteLine($"Starting in {currentTime:hh:mm}, ending in {endingTime:hh:mm}");

            while (endingTime > currentTime)
            {
                var time = (endingTime - currentTime);
                var timeInMinutes = time.ToString().Split(".");

                Console.WriteLine(!isBreak ? $"Remaining time: {timeInMinutes[0]}" : $"Remaining break time: {timeInMinutes[0]}");

                currentTime = currentTime.AddSeconds(1);
                Thread.Sleep(1000);
            }

            Console.WriteLine(!isBreak ? "Starting break in 2 seconds" : "Starting pomodoro again in 2 seconds");
            Thread.Sleep(2000);

            StartTimer(!isBreak);
        }
        private static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Bye!");
        }
    }
}