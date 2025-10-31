using Perfolizer.Metrology;
using Perfolizer.Models;

namespace BenchmarkDotNet.Tests.Perfonar.Infra;

public static class PerfonarTestExtensions
{
    public static EntryInfo AddMetrics(this EntryInfo entry, params string[] metrics)
    {
        for (int i = 0; i < metrics.Length; i++)
        {
            var measurement = PerfolizerMeasurementFormatter.Instance.Parse(metrics[i]);
            entry.Add(new EntryInfo
            {
                IterationIndex = i,
                Value = measurement.NominalValue,
                Unit = measurement.Unit
            });
        }
        return entry;
    }
}