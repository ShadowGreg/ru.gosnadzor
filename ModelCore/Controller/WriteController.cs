using System.Collections.Generic;

namespace ru.gosnadzor.Controller.CsvController;

public abstract class WriteController
{
    protected string filePath;

    protected WriteController(string filePath)
    {
        this.filePath = filePath;
    }

    public abstract void writeFile(List<List<string>> inData);

}