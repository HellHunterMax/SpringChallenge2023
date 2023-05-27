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
                if (objective.Cell.Resources < 1)
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

                Console.WriteLine(Actions.LINE(homeCell.Id, currentObjective.Cell.Id, 1));
            }

            // WAIT | LINE <sourceIdx> <targetIdx> <strength> | BEACON <cellIdx> <strength> | MESSAGE <text>

        }
    }
}

//net5.0-windows-v1.0\CSharpSourcesToSingleFile.exe -d C:\Repo\CodinGame\SpringChallenge2023 -o merge.cs
//Console.Error.WriteLine($"");
//Console.Error.WriteLine($"");
// Write an action using Console.WriteLine()
// To debug: Console.Error.WriteLine("Debug messages...");