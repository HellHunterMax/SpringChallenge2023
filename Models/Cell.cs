public class Cell
{
    public int Id { get; set; }
    public CellTypeEnum CellType { get; set; }
    public int Resources { get; set; } //for the amount of crystal/egg here.
    private List<int> _Neighbours { get; set; } = new List<int>(); //neigh variables: Ignore for this league.
    public int FriendlyAnts { get; set; }
    public int EnemyAnts { get; set; }
    public List<Cell> Neighbours { get; set; } = new List<Cell>();


    public Cell(int id, CellTypeEnum cellType, int resources, List<int> neighbours)
    {
        Id = id;
        CellType = cellType;
        Resources = resources;
        _Neighbours = neighbours;
    }

    public void SetNeighbours(Map map)
    {
        foreach (var id in _Neighbours)
        {
            Neighbours.Add(map.Cells.Find(x => x.Id == id));
        }
    }

}