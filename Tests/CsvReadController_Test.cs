using ru.gosnadzor.Controller.CsvController;

namespace TestProject1;

public class CsvReadController_Test
{
    private ReadController rc;
    private static readonly string path = "C:/workspace/ru.gosnadzor/ru.gosnadzor/Data/a1.csv";
    [SetUp]
    public void Setup()
    {
        rc = new CsvReadController(path);
    }
    [Test]
    public void Create_Answers()
    {
        Setup();
        
        Assert.That(rc.readFile(), Is.Not.Null);
    }
    [Test]
    public void Create_GetSomeText_Test()
    {
        Setup();
        const string expected = "Какие требования не могут быть отнесены к лицензионным требованиям?    Укажите все правильные ответы";
        
        var actual = rc.readFile()[0][0];
        
        Assert.AreEqual(expected, actual);
    }
}