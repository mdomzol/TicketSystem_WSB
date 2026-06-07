namespace TicketSystem.ConsoleUI.Helpers
{
    public static class InputHelper
    {
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                ConsoleMessages.Error("Pole nie może być puste!");
            }
        }

        public static string ReadChoice(string prompt, params string[] allowed)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (allowed.Contains(input))
                    return input;

                ConsoleMessages.Error("Niepoprawny wybór.");
            }
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                ConsoleMessages.Error("Wpisz poprawną liczbę.");
            }
        }
    }
}