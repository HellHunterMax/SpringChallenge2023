public class Objective
{
    public bool Completed { get; set; } = false;
    public int turns { get; set; } = 0;
    public Cell StartCell { get; set; }
    public Cell ObjectiveCell { get; set; }
    public CellTypeEnum ObjectiveCellType { get; set; }
    public int Distance { get; set; }

    public Objective(Cell startCell, Cell objectiveCell, int distance)
    {
        StartCell = startCell;
        ObjectiveCell = objectiveCell;
        ObjectiveCellType = objectiveCell.CellType;
        Distance = distance;
    }

    public override string ToString()
    {
        return $"StartCell {StartCell.Id}, ObjectiveCell Id={ObjectiveCell.Id} resources={ObjectiveCell.Resources}, Distance={Distance}";
    }

}