class Player
{
    static void Main(string[] args)
    {
        var map = GameParser.ParseStartGame();
        List<Objective> currentObjectives = new List<Objective>();

        // game loop
        while (true)
        {
            GameParser.UpdateMapForTurn(map);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            foreach (var objective in currentObjectives)
            {
                if (objective.Completed)
                {
                    continue;
                }
                if (objective.ObjectiveCell.Resources < 1)
                {
                    objective.Completed = true;
                }
            }

            if (currentObjectives.All(x => x.Completed))
            {
                var objective = ObjectiveService.GetObjective(map);
                if (objective is not null)
                {
                    currentObjectives.Add(objective);
                }
            }

            if (currentObjectives.All(x => x.Completed))
            {
                Console.WriteLine(Actions.WAIT());
            }
            else
            {
                var homeCell = map.Cells[map.FriendlyBases.First()];
                var currentObjective = currentObjectives.First(x => !x.Completed);

                Console.WriteLine(Actions.LINE(homeCell.Id, currentObjective.ObjectiveCell.Id, 1));
            }

            // WAIT | LINE <sourceIdx> <targetIdx> <strength> | BEACON <cellIdx> <strength> | MESSAGE <text>

        }
    }
}