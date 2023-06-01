public class Map
{
    public List<Cell> Cells = new List<Cell>();
    public List<int> FriendlyBases = new List<int>();
    public List<int> EnemyBases = new List<int>();
    public int Crystals { get; set; }
    public int FriendlyAnts { get; set; }
    public int Eggs { get; set; }

    public void UpdateMap()
    {
        Crystals = 0;
        FriendlyAnts = 0;
        Eggs = 0;
        foreach (var cell in Cells)
        {
            CountCellTypesOnMap(cell);
            CountAntsOnMap(cell);
        }
    }

    private void CountCellTypesOnMap(Cell cell)
    {
        switch (cell.CellType)
        {
            case CellTypeEnum.Egg:
                Eggs += cell.Resources;
                break;
            case CellTypeEnum.Crystal:
                Crystals += cell.Resources;
                break;
            default:
                break;
        }
    }
    private void CountAntsOnMap(Cell cell)
    {
        FriendlyAnts += cell.FriendlyAnts;
    }

    public Cell GetExistingCell(int id)
    {
        return Cells.First(x => x.Id == id);
    }
}