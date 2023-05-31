public static class ObjectiveExtensions
{
    public static void WriteActions(this List<Objective> objectives)
    {
        var sb = new StringBuilder();
        foreach (var objective in objectives)
        {
            sb.Append(Actions.LINE(objective.StartCell.Id, objective.ObjectiveCell.Id, 1));
            sb.Append(";");
        }
        sb.Remove(sb.Length - 1, 1);
        Console.WriteLine(sb.ToString());
    }

    public static void LogObjectives(this List<Objective> objectives)
    {
        foreach (var objective in objectives)
        {
            Console.Error.WriteLine(objective);
        }
    }
}