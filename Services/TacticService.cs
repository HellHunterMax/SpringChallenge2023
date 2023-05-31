public class TacticService
{
    public List<Objective> CrystalObjectives { get; set; } = new List<Objective>();
    public List<Objective> EggObjectives { get; set; }
    public Map Map { get; }
    public Cell HomeCell { get; }

    public TacticService(Map map, Cell homeCell)
    {
        Map = map;
        HomeCell = homeCell;
        EggObjectives = ObjectiveService.FindCellWithCellType(map, homeCell, CellTypeEnum.Egg).OrderBy(x => x.Distance).ToList();
        CrystalObjectives = ObjectiveService.FindCellWithCellType(map, homeCell, CellTypeEnum.Crystal).OrderBy(x => x.Distance).ToList();

    }

    public List<Objective>? getComboObjective()
    {
        var objectives = new Dictionary<Objective, List<Objective>>();

        //TODO Get CrystalObjective if no objectives with eggs.

        if (!EggObjectives.Any())
        {
            Console.Error.WriteLine($"did not find any EggObjectives returning null.");
            return null;
        }

        Console.Error.WriteLine($"looping over eggObjectives to make lists.");

        foreach (var EggObjective in EggObjectives)
        {
            var objectivesFromEggs = new List<Objective>();
            objectives.Add(EggObjective, ObjectiveService.FindCellWithCellType(Map, EggObjective.ObjectiveCell, CellTypeEnum.Crystal).OrderBy(x => x.Distance).ToList());
        }
        Console.Error.WriteLine($"Creating bestObjective.");

        var bestObjective = new List<Objective>()
        {
            objectives.First().Key
        };
        Console.Error.WriteLine($"Finding Crystals for EggObjective.");
        var maxDistance = objectives.First().Value.Max(x => x.Distance);
        var count = 1;
        while (bestObjective.Count < 2 || count > maxDistance)
        {
            bestObjective.AddRange(
            objectives.First().Value.Where(x => x.Distance < count));
            count++;
        }

        return bestObjective;
    }

    public void UpdateObjectives()
    {
        Console.Error.WriteLine($"updating TacticService for turn.");
        CrystalObjectives.RemoveAll(x => x.ObjectiveCell.Resources == 0);
        EggObjectives.RemoveAll(x => x.ObjectiveCell.Resources == 0);
        EggObjectives.LogObjectives();
    }
}