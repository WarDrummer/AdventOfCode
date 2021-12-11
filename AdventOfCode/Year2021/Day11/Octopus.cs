namespace AdventOfCode.Year2021.Day11
{
    public class Octopus
    {
        public int Energy { get; set; }
        public bool HasFlashed { get; set; }
        public Point Location { get; set; }

        public void Reset()
        {
            if (HasFlashed)
            {
                Energy = 0;
            }
            HasFlashed = false;
        }

        public void AttemptFlash(Grid<Octopus> grid)
        {
            if (Energy > 9 && !HasFlashed)
            {
                HasFlashed = true;
                for (var y = Location.Y - 1; y <= Location.Y + 1; y++)
                {
                    for (var x = Location.X - 1; x <= Location.X + 1; x++)
                    {
                        if (Location.X != x || Location.Y != y)
                        {
                            var adjacentOctopus = grid[new Point(x, y)];
                            if(adjacentOctopus != null)
                            {
                                adjacentOctopus.Energy += 1;
                                adjacentOctopus.AttemptFlash(grid);
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return Energy.ToString();
        }
    }
}