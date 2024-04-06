// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;


namespace ConsoleApp1
{
    /// <summary>
    /// Interface bör flyttas till en Ifile
    /// </summary>
    public interface IGreetingService
    {
        void Greet(string name);
    }
    
    /// <summary>
    /// Interface bör flyttas till en Ifile
    /// </summary>
    public interface IGreetingNumberService
    {
        void GreetNumber(int number);
    }

    /// <summary>
    /// Interface bör flyttast till en Ifile
    /// </summary>
    public interface IGreetingBoolService
    {
        void GreetBool(bool boolean);
    }
    
    /// <summary>
    /// Definierar en klass GreetingNumber som implementerar gränssnittet IGreetingNumberService
    /// måste implementera alla metoder definierade i IGreetingNumberService.
    /// skapar en instans av Interface
    /// </summary>
    public class GreetingNumber : IGreetingNumberService
    {
        public void GreetNumber(int number)
        {
            Console.WriteLine($"Var det detta,{number}");
        }
    }
    
    /// <summary>
    /// Skapar en instans av interfaces 
    /// </summary>
    public class GreetingService : IGreetingService
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Hej,{name}");
        }
    }

    public class GreetingBool : IGreetingBoolService
    {
        public void GreetBool(bool boolean)
        {
            Console.WriteLine($"Sant eller falskt? {boolean}");
        }
    }

    /// <summary>
    /// Skapar en ny ServiceCollection som kommer att innehålla alla registreringar av tjänster.
    /// Registrerar IGreetingService för att använda GreetingService. Varje gång IGreetingService efterfrågas,
    /// kommer en ny instans av GreetingService att skapas (eftersom det är Transient).
    /// Liksom ovanstående, men för IGreetingNumberService och GreetingNumber.
    /// Det innebär att varje gång IGreetingNumberService efterfrågas, skapas en ny instans av GreetingNumber.
    /// Bygger en ServiceProvider från vår service collection. Detta gör det möjligt för oss att efterfråga
    /// tjänster som har registrerats i vår ServiceCollection.
    /// Begär en instans av IGreetingService från ServiceProvider. En ny instans av GreetingService returneras.
    /// Begär en instans av IGreetingNumberService från ServiceProvider. En ny instans av GreetingNumber returneras.
    /// Använder den erhållna instansen av IGreetingService för att anropa Greet-metoden med strängen "Hello Dip".
    /// Anropar Greet-metoden igen med en annan sträng, "en till", för att visa att samma instans används
    /// inom samma scope, men en ny skulle skapas vid nästa begäran om tjänsten är transient.
    /// Använder den erhållna instansen av IGreetingNumberService för att anropa GreetNumber-metoden med talet 2.
    /// </summary>
    public class Dip
    {
        public void DipContain()
        {
            var services = new ServiceCollection();

            services.AddTransient<IGreetingService, GreetingService>();
            services.AddTransient<IGreetingNumberService, GreetingNumber>();
            services.AddTransient<IGreetingBoolService, GreetingBool>();

            var serviceProvider = services.BuildServiceProvider();
            var greetingService = serviceProvider.GetService<IGreetingService>();
            var greetingNumberService = serviceProvider.GetService<IGreetingNumberService>();
            var greetingBooleanService = serviceProvider.GetService<IGreetingBoolService>();

            greetingService?.Greet("Testar nu Dependecy injection");
            greetingService?.Greet("test 2");
            greetingNumberService?.GreetNumber(2);
            greetingBooleanService?.GreetBool(true);
        }
    }
    internal static class Program
    {
        internal static void Main()
        {
            var dipiClass = new Dip();
            dipiClass.DipContain();

        }

    }
    
}