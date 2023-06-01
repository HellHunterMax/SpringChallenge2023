
global using System;
global using System.Linq;
global using System.IO;
global using System.Text;
global using System.Collections;
global using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        var map = GameParser.ParseStartGame();
        List<Objective> currentObjectives = new List<Objective>();
        var homeCell = map.Cells[map.FriendlyBases.First()];
        var _tacticeService = new TacticService(map, homeCell);

        // game loop
        while (true)
        {
            GameParser.UpdateMapForTurn(map);

            var comboObjective = _tacticeService.getObjective();

            if (comboObjective != null)
            {
                comboObjective.LogObjectives();
                comboObjective.WriteActions();
                _tacticeService.UpdateObjectives();
                continue;
            }

            Console.Error.WriteLine($"Did not find comboObjectives going to CrystalObjective.");
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            GetCrystalObjective(map, currentObjectives, homeCell);

            // WAIT | LINE <sourceIdx> <targetIdx> <strength> | BEACON <cellIdx> <strength> | MESSAGE <text>

        }
    }

    private static void GetCrystalObjective(Map map, List<Objective> currentObjectives, Cell homeCell)
    {
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
            var objective = ObjectiveService.FindCellWithCellType(map, homeCell, CellTypeEnum.Crystal);
            if (objective is not null)
            {
                currentObjectives.AddRange(objective);
            }
        }

        if (currentObjectives.All(x => x.Completed))
        {
            Console.WriteLine(Actions.WAIT());
        }
        else
        {
            var currentObjective = currentObjectives.First(x => !x.Completed);

            Console.WriteLine(Actions.LINE(homeCell.Id, currentObjective.ObjectiveCell.Id, 1));
        }
    }
}