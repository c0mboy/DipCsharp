using ConsoleApp1;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void Greet_ShouldOutputExpectedMessage()
    {
        // Arrange
        // Skapar en instans av klassen GreetingBool
        var service = new GreetingService();
        var name = "Hej,";
        
        //Skapar en StringWriter för att fånga utskriften från Console.WriteLine.
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        // Act
        // Kallar vi på Greet-metoden med det förberedda namnet  
        service.Greet(name);
        
        // Assert
        // Här kontrollerar vi att det som skrivits ut till vår StringWriter matchar det förväntade meddelandet. 
        var expected = $"Hej,{name}\r\n"; // Observera att Console.WriteLine lägger till en ny rad
        Assert.That(sw.ToString(), Is.EqualTo(expected));
    }
    [Test]
    public void GreetingBool_ShouldOutputExpectedMessage()
    {
        // Arrange
        // Skapar en instans av klassen GreetingBool
        var service = new GreetingBool();
        var boolean = true;
        
        // Skapar en StringWriter för att fånga utskriften från Console.WriteLine.
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        // Act
        // Kallar vi på Greet-metoden med det förberedda namnet 
        service.GreetBool(boolean);
        
        // Assert
        // Här kontrollerar vi att det som skrivits ut till vår StringWriter matchar det förväntade meddelandet.
        var expected = $"Sant eller falskt? {boolean}\r\n"; // Observera att Console.WriteLine lägger till en ny rad
        Assert.That(sw.ToString(), Is.EqualTo(expected));
    } 
    
    [Test]
    public void GreetingInt_ShouldOutputExpectedMessage()
    {
        // Arrange
        // Skapar en instans av klassen GreetingNumber
        var service = new GreetingNumber();
        var numbers = 2;
        
        // Skapar en StringWriter för att fånga utskriften från Console.WriteLine.
        using var sw = new StringWriter();
        Console.SetOut(sw);
        
        // Act
        // Kallar vi på Greet-metoden med det förberedda namnet
        service.GreetNumber(numbers);
        
        // Assert
        // Här kontrollerar vi att det som skrivits ut till vår StringWriter matchar det förväntade meddelandet.
        var expected = $"Var det detta,{numbers}\r\n"; // Observera att Console.WriteLine lägger till en ny rad
        Assert.That(sw.ToString(), Is.EqualTo(expected));
    } 
    
}
