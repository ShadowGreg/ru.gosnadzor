using ru.gosnadzor.Controller.CsvController;
using ru.gosnadzor.Convertor;
using ru.gosnadzor.Model;

namespace TestProject1;

public class CsvConverter_Test
{
    private CsvConverter _csvConverter;
    private static readonly string path = "C:/workspace/ru.gosnadzor/ru.gosnadzor/Data/a1.csv";


    [SetUp]
    public void Setup()
    {
        _csvConverter = new CsvConverter(new CsvReadController(path),new BaseQuestion());
    }
    [Test]
    public void CsvConverter_Create_Test()
    {
        Setup();
        Assert.That(_csvConverter, Is.Not.Null);
    }
    [Test]
    public void getQuestions_NotNull()
    {
        Setup();
        Assert.That(_csvConverter.getQuestions(), Is.Not.Null);
    }
    [Test]
    public void getQuestions_Correct()
    {
        Setup();
        BaseQuestion expected = GetCorrectQuestion();

        BaseQuestion actual = _csvConverter.getQuestions()[0];
        
        Assert.That(expected, Is.EqualTo(actual));
    }

    private BaseQuestion GetCorrectQuestion()
    {
        List<BaseAnswer> list = new()
        {
            new Answer("Требования о соответствии соискателя лицензии и лицензиата требованиям, установленным федеральными законами и касающимся организационно-правовой формы юридического лица, размера уставного капитала, отсутствия задолженности по обязательствам перед третьими лицами.",false),
            new Answer("Требования к конкретным видам и объему выпускаемой или планируемой к выпуску продукции.",true),
            new Answer()
        };
        Answers answers = new Answers(list); 
        return new BaseQuestion()
        {
            text = "Какие требования не могут быть отнесены к лицензионным требованиям?    Укажите все правильные ответы",
            answersInQuestion = answers
        } ;
    }
}