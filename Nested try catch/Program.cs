// See https://aka.ms/new-console-template for more information

try
{
    try
    {
        // إلقاء الأستثناء الأول يتم التقاطه بواسطة الكاتش الداخلية
        throw new Exception("First Exception");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Inner Catch Block: " + ex.Message);
        // إلقاء الأستثناء الثاني يتم التقاطه بواسطة الكاتش الخارجية
        throw new Exception("Second Exception");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Outer Catch Block: " + ex.Message);
}

Console.ReadLine();
    
