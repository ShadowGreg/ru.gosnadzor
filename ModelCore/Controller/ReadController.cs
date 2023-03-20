using System.Collections.Generic;

namespace ru.gosnadzor.Controller.CsvController;

public abstract class ReadController
{
    protected string filePath;


    protected ReadController(string filePath)
    {
        this.filePath = filePath;
    }

    public abstract List<List<string?>> readFile();
}