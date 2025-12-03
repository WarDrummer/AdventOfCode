using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Year2021.Day11;

public class Grid<T> where T: new()
{
    public delegate void UpdateCell(Point pt, Grid<T> grid);

    private readonly Dictionary<Point, T> _grid = new ();
    private readonly int _xMax;
    private readonly int _yMax;
        
    public T this[Point pt] => _grid.ContainsKey(pt) ? _grid[pt] : default;

    public Grid(IReadOnlyList<List<T>> lines)
    {
        _yMax = lines.Count;
        _xMax = lines[0].Count;
        for (var y = 0; y < lines.Count; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Count; x++)
            {
                var value = line[x];
                _grid[new Point(x, y)] = value;
            }
        }
    }
    
    public void ApplyUpdates(UpdateCell updateCell)
    {
        foreach (var pt in _grid.Keys)
        {
            updateCell(pt, this);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < _yMax; y++)
        {
            for (var x = 0; x < _xMax; x++)
            {
                var pt = new Point(x, y);
                sb.Append(_grid[pt]);
            }
    
            sb.AppendLine();
        }
    
        return sb.ToString();
    }
}