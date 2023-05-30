public static class ObjectiveService
{
    public static Objective? FindCellWithCellType(Map map, Cell startingCell, CellTypeEnum celltypeToLookFor)
    {
        List<int> visited = new List<int>();
        List<Cell> toVisit = new List<Cell>();
        Queue<Cell> queue = new Queue<Cell>();
        int distance = 1;

        visited.Add(startingCell.Id);

        toVisit.Add(startingCell);
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

                if (currentCell.CellType == celltypeToLookFor && currentCell.Resources > 0)
                {
                    return new Objective(startingCell, currentCell, distance);
                }

                foreach (Cell neighbour in currentCell.Neighbours)
                {
                    if (!visited.Contains(neighbour.Id))
                    {
                        visited.Add(neighbour.Id);
                        toVisit.Add(neighbour);
                    }
                }
            }
            distance++;
        }
        return null;  // No cell with crystals found
    }
}