using System.Linq;

namespace AdventOfCode.Year2021.Day03
{
    public class Day03B : Day03A
    {
        public override string Solve()
        {
            var diagnostics = GetDiagnosticStrings();
            var diagnosticCodes = GetDiagnosticCodes(diagnostics);
            var diagnosticSize = diagnostics[0].Length;
        
            var diagnosticsClone = diagnosticCodes.ToList();
            for (var i = diagnosticSize - 1; i >= 0; i--)
            {
                var numCodes = diagnosticsClone.Count;
                var count = diagnosticsClone.Count(item => item.IsBitSet(i)) * 2;
                var most = count >= numCodes;
                for (var j = diagnosticsClone.Count - 1; j >= 0; j--)
                {
                    if (diagnosticsClone[j].IsBitSet(i) != most)
                        diagnosticsClone.RemoveAt(j);
                }
                if (diagnosticsClone.Count < 2)
                    break;
            }
            var oxygen = diagnosticsClone[0];
            
            diagnosticsClone = diagnosticCodes.ToList();
            for (var i = diagnosticSize - 1; i >= 0; i--)
            {
                var numCodes = diagnosticsClone.Count;
                var count = diagnosticsClone.Count(item => item.IsBitSet(i)) * 2;
                var most = count >= numCodes;
                for (var j = diagnosticsClone.Count - 1; j >= 0; j--)
                {
                    if (diagnosticsClone[j].IsBitSet(i) == most)
                        diagnosticsClone.RemoveAt(j);
                }
                if (diagnosticsClone.Count < 2)
                    break;
            }
            var co2 = diagnosticsClone[0];
            
            return (oxygen * co2).ToString();
        }
    }
}