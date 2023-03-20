using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;


namespace ru.gosnadzor.Controller.CsvController;

public class CsvReadController : ReadController
{
    public CsvReadController(string filePath) : base(filePath)
    {
    }

    public override List<List<string?>> readFile()
    {
        StreamReader sr = new(base.filePath, Encoding.Default);
        CsvConfiguration config = new(CultureInfo.InvariantCulture)
        {
            BadDataFound = null,
            Delimiter = ";"
        };

        CsvReader csv = new(sr, config);
        IEnumerable<CsvFields> records = csv.GetRecords<CsvFields>();

        return records.Select(VARIABLE => VARIABLE.getVolume()).ToList();
    }


    // ReSharper disable once ClassNeverInstantiated.Local
    private class CsvFields
    {
        // ReSharper disable once MemberCanBePrivate.Local
        public string? first { get; set; }
        // ReSharper disable once MemberCanBePrivate.Local
        public string? second { get; set; }
        // ReSharper disable once MemberCanBePrivate.Local
        public string? therd { get; set; }
        // ReSharper disable once MemberCanBePrivate.Local
        public string? forth { get; set; }

        public List<string?> getVolume()
        {
            first ??= "";
            second ??= "";
            therd ??= "";
            forth ??= "";
            return new List<string?>()
            {
                first,
                second,
                therd,
                forth
            };
        }
    }
}