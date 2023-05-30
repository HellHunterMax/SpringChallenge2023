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
        if (map is null)
        {
            throw new Exception("Map must be given to set neighbours");
        }

        foreach (var id in _Neighbours)
        {
            var cell = map.Cells.Find(x => x.Id == id);
            if (cell is not null)
            {
                Neighbours.Add(cell);
            }
        }
    }

}