public static class ObjectiveService
{
    public static List<Objective> FindCellWithCellType(Map map, Cell startingCell, CellTypeEnum celltypeToLookFor)
    {
        List<Objective> objectives = new List<Objective>();
        List<int> visited = new List<int>();
        List<Cell> toVisit = new List<Cell>();
        Queue<Cell> queue = new Queue<Cell>();
        int distance = 1;

        visited.Add(startingCell.Id);

        toVisit.Add(startingCell);
        var number = 0;
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
                    objectives.Add(new Objective(startingCell, currentCell, distance));
                }

                foreach (Cell neighbour in currentCell.Neighbours)
                {
                    number++;
                    Console.Error.Write($"{number}, ");
                    if (!visited.Contains(neighbour.Id))
                    {
                        visited.Add(neighbour.Id);
                        toVisit.Add(neighbour);
                    }
                }
            }
            distance++;
        }
        return objectives;  // No cell with crystals found
    }
}