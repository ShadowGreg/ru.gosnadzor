
using ru.gosnadzor.Model;

namespace TestProject1;

public class AnswersTests
{
    private List<BaseAnswer>? _answers;
    private Answers? _testAnswers;

    [SetUp]
    public void Setup()
    {
        _answers = new List<BaseAnswer>();
        const int answerCount = 4;
        const int correctAnswer = 3;
        for (int i = 0; i < answerCount; i++)
        {
            _answers.Add(i == correctAnswer ? new Answer($"Test_text{i}", true) : new Answer($"Test_text{i}", false));
        }

        _testAnswers = new Answers(_answers);
    }

    [Test]
    public void Create_Answers()
    {
        Assert.That(_testAnswers, Is.Not.Null);
    }

    [Test]
    public void GetAnswers_Test()
    {
        List<string> expectedAnswers = new()
        {
            "Test_text0",
            "Test_text1",
            "Test_text2",
            "Test_text3"
        };

        if (_testAnswers != null)
        {
            List<string?> actualAnswers = _testAnswers.GetAnswers();

            Assert.That(actualAnswers, Is.EqualTo(expectedAnswers));
        }
    }

    [Test]
    public void IsAnswerCorrect_True_Test()
    {
        const bool expected = true;
        
        Setup();
        bool actual = _testAnswers != null && _testAnswers.IsAnswerCorrect("Test_text3");

        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void IsAnswerCorrect_False_Test()
    {
        const bool expected = false;
        
        Setup();
        bool actual = _testAnswers != null && _testAnswers.IsAnswerCorrect("Test_text1");

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void IsCorrectlyBefore_True_Test()
    {
        const bool expected = true;
        
        Setup();
        if (_testAnswers != null)
        {
            _testAnswers.IsAnswerCorrect("Test_text3");
            bool actual = _testAnswers.IsCorrectlyBefore();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [Test]
    public void IsCorrectlyBefore_False_Test()
    {
        const bool expected = false;
        
        Setup();
        if (_testAnswers != null)
        {
            _testAnswers.IsAnswerCorrect("Test_text1");
            bool actual = _testAnswers.IsCorrectlyBefore();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

}