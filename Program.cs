using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select the input temperature unit:");
            Console.WriteLine("1. Celsius");
            Console.WriteLine("2. Fahrenheit");
            Console.WriteLine("3. Kelvin");
            Console.WriteLine("0. Exit");

            string inputChoice = Console.ReadLine();

            if (inputChoice == "0")
                break;

            Console.WriteLine("Select the output temperature unit:");
            Console.WriteLine("1. Celsius");
            Console.WriteLine("2. Fahrenheit");
            Console.WriteLine("3. Kelvin");

            string outputChoice = Console.ReadLine();

            try
            {
                double inputTemperature = GetTemperatureInput("Enter the temperature: ");
                double result;

                switch (inputChoice)
                {
                    case "1":
                        result = ConvertFromCelsius(outputChoice, inputTemperature);
                        break;
                    case "2":
                        result = ConvertFromFahrenheit(outputChoice, inputTemperature);
                        break;
                    case "3":
                        result = ConvertFromKelvin(outputChoice, inputTemperature);
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        continue;
                }

                Console.WriteLine($"Converted temperature: {result}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    static double GetTemperatureInput(string message)
    {
        Console.Write(message);
        if (double.TryParse(Console.ReadLine(), out double temperature))
        {
            return temperature;
        }
        else
        {
            throw new ArgumentException("Invalid input. Please enter a valid number.");
        }
    }

    static double ConvertFromCelsius(string outputChoice, double celsius)
    {
        if (celsius < -273.15)
            throw new ArgumentException("Temperature below absolute zero is not allowed.");

        switch (outputChoice)
        {
            case "1":
                return celsius;
            case "2":
                return (celsius * 9 / 5) + 32;
            case "3":
                return celsius + 273.15;
            default:
                throw new ArgumentException("Invalid output selection.");
        }
    }

    static double ConvertFromFahrenheit(string outputChoice, double fahrenheit)
    {
        if (fahrenheit < -459.67)
            throw new ArgumentException("Temperature below absolute zero is not allowed.");

        switch (outputChoice)
        {
            case "1":
                return (fahrenheit - 32) * 5 / 9;
            case "2":
                return fahrenheit;
            case "3":
                return (fahrenheit + 459.67) * 5 / 9;
            default:
                throw new ArgumentException("Invalid output selection.");
        }
    }

    static double ConvertFromKelvin(string outputChoice, double kelvin)
    {
        if (kelvin < 0)
            throw new ArgumentException("Temperature below absolute zero is not allowed.");

        switch (outputChoice)
        {
            case "1":
                return kelvin - 273.15;
            case "2":
                return (kelvin * 9 / 5) - 459.67;
            case "3":
                return kelvin;
            default:
                throw new ArgumentException("Invalid output selection.");
        }
    }
}
