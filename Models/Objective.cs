public class Objective
{
    public bool Completed { get; set; } = false;
    public int turns { get; set; } = 0;
    public Cell StartCell { get; set; }
    public Cell ObjectiveCell { get; set; }
    public CellTypeEnum ObjectiveCellType { get; set; }

    public Objective(Cell startCell, Cell objectiveCell)
    {
        StartCell = startCell;
        ObjectiveCell = objectiveCell;
        ObjectiveCellType = objectiveCell.CellType;
    }

}