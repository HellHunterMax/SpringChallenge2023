public static class ObjectiveService
{
    public static Objective? GetObjective(Map map)
    {
        var homeCell = map.Cells[map.FriendlyBases.First()];
        var cell = GetClosestCellWithCrystals(map, homeCell);
        if (cell is null)
        {
            return null;
        }

        return new Objective(homeCell, cell);
    }

    private static Cell? GetClosestCellWithCrystals(Map map, Cell homeCell)
    {
        return FindCellWithCrystals(map, homeCell);
    }

    public static Cell? FindCellWithCrystals(Map map, Cell homeCell)
    {
        List<int> visited = new List<int>();
        Queue<Cell> queue = new Queue<Cell>();

        visited.Add(homeCell.Id);
        queue.Enqueue(homeCell);

        while (queue.Count > 0)
        {
            Cell currentCell = queue.Dequeue();

            if (currentCell.CellType == CellTypeEnum.Crystal && currentCell.Resources > 0)
            {
                return currentCell;  // Found a cell with crystals
            }

            foreach (Cell neighbour in currentCell.Neighbours)
            {
                if (!visited.Contains(neighbour.Id))
                {
                    visited.Add(neighbour.Id);
                    queue.Enqueue(neighbour);
                }
            }
        }

        return null;  // No cell with crystals found
    }
}