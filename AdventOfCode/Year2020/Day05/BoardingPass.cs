namespace AdventOfCode.Year2020.Day05
{
    public class BoardingPass
    {
        private string Seat { get; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId => Row * 8 + Column;
        
        public BoardingPass(string seat)
        {
            Seat = seat;
            Row = (seat[0] == 'B' ? 1<<6 : 0) | 
                  (seat[1] == 'B' ? 1<<5 : 0) | 
                  (seat[2] == 'B' ? 1<<4 : 0) | 
                  (seat[3] == 'B' ? 1<<3 : 0) | 
                  (seat[4] == 'B' ? 1<<2 : 0) | 
                  (seat[5] == 'B' ? 1<<1 : 0) | 
                  (seat[6] == 'B' ? 1<<0 : 0);

            Column = (seat[7] == 'R' ? 1 << 2 : 0) |
                     (seat[8] == 'R' ? 1 << 1 : 0) |
                     (seat[9] == 'R' ? 1 << 0 : 0);
        }
        
        public BoardingPass(int row, int column)
        {
            Row = row;
            Column = column;
            var seat = new char[10];
            seat[0] = (row & 64) != 0 ? 'B' : 'F';
            seat[1] = (row & 32) != 0 ? 'B' : 'F';
            seat[2] = (row & 16) != 0 ? 'B' : 'F';
            seat[3] = (row &  8) != 0 ? 'B' : 'F';
            seat[4] = (row &  4) != 0 ? 'B' : 'F';
            seat[5] = (row &  2) != 0 ? 'B' : 'F';
            seat[6] = (row &  1) != 0 ? 'B' : 'F';
            
            seat[7] = (column &  4) != 0 ? 'R' : 'L';
            seat[8] = (column &  2) != 0 ? 'R' : 'L';
            seat[9] = (column &  1) != 0 ? 'R' : 'L';
        }

        public override string ToString()
        {
            return $"{Seat}: row {Row}, column {Column}, seat ID {SeatId}";
        }
    }
}