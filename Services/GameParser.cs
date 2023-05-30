public static class GameParser
{
    public static Map ParseStartGame()
    {
        Map map = new Map();
        string[] inputs;
        int numberOfCells = int.Parse(Console.ReadLine()!); // amount of hexagonal cells in this map
        for (int i = 0; i < numberOfCells; i++)
        {
            inputs = Console.ReadLine()!.Split(' ');
            int type = int.Parse(inputs[0]); // 0 for empty, 1 for eggs, 2 for crystal
            int initialResources = int.Parse(inputs[1]); // the initial amount of eggs/crystals on this cell
            var neighbours = new List<int>();

            AddNeighbour(neighbours, int.Parse(inputs[2]));
            AddNeighbour(neighbours, int.Parse(inputs[3]));
            AddNeighbour(neighbours, int.Parse(inputs[4]));
            AddNeighbour(neighbours, int.Parse(inputs[5]));
            AddNeighbour(neighbours, int.Parse(inputs[6]));
            AddNeighbour(neighbours, int.Parse(inputs[7]));

            Cell newCell = new Cell(i, (CellTypeEnum)type, initialResources, neighbours);
            map.Cells.Add(newCell);
        }

        MapBases(map);
        MapNeigboursOnCells(map);

        foreach (Cell cell in map.Cells)
        {
            Console.Error.WriteLine($"CellId={cell.Id} Neighbours={cell.Neighbours.Count} Resources={cell.Resources}");
        }
        return map;
    }

    public static void AddNeighbour(List<int> neighbours, int id)
    {
        if (id >= 0)
        {
            neighbours.Add(id);
        }
    }

    public static void UpdateMapForTurn(Map map)
    {
        string[] inputs;
        for (int i = 0; i < map.Cells.Count; i++)
        {
            inputs = Console.ReadLine()!.Split(' ');
            map.Cells[i].Resources = int.Parse(inputs[0]); // the current amount of eggs/crystals on this cell
            map.Cells[i].FriendlyAnts = int.Parse(inputs[1]); // the amount of your ants on this cell
            map.Cells[i].EnemyAnts = int.Parse(inputs[2]); // the amount of opponent ants on this cell
        }
    }

    private static void MapBases(Map map)
    {
        string[] inputs;
        int numberOfBases = int.Parse(Console.ReadLine()!);

        inputs = Console.ReadLine()!.Split(' ');
        for (int i = 0; i < numberOfBases; i++)
        {
            map.FriendlyBases.Add(int.Parse(inputs[i]));
        }
        inputs = Console.ReadLine()!.Split(' ');
        for (int i = 0; i < numberOfBases; i++)
        {
            map.EnemyBases.Add(int.Parse(inputs[i]));
        }
    }
    private static void MapNeigboursOnCells(Map map)
    {
        foreach (Cell cell in map.Cells)
        {
            cell.SetNeighbours(map);
        }
    }
}