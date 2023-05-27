public class Map
{
    public List<Cell> Cells = new List<Cell>();
    public List<int> FriendlyBases = new List<int>();
    public List<int> EnemyBases = new List<int>();

    public Cell GetExistingCell(int id)
    {
        return Cells.First(x => x.Id == id);
    }
}