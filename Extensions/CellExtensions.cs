public static class CellExtensions
{
    public static int GetDistanceTo(this Cell startCell, Cell EndCell)
    {
        List<Cell> visited = new List<Cell>();
        List<Cell> toVisit = new List<Cell>();
        Queue<Cell> queue = new Queue<Cell>();
        int distance = 1;

        visited.Add(startCell);

        toVisit.Add(startCell);
        while (toVisit.Any())
        {
            foreach (var cell in toVisit)
            {
                queue.Enqueue(cell);
            }
            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();
                toVisit.Remove(currentCell);

                if (currentCell == EndCell)
                {
                    return distance;
                }

                foreach (Cell neighbour in currentCell.Neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        toVisit.Add(neighbour);
                    }
                }
            }
            distance++;
        }
        return -1;  // No cell with crystals found
    }
}