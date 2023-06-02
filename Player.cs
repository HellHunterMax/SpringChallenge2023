
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
        var homeCell = map.Cells[map.FriendlyBases.First()];
        var _tacticeService = new TacticService(map, homeCell);

        // game loop
        while (true)
        {
            GameParser.UpdateMapForTurn(map);

            var comboObjectives = _tacticeService.getObjectives();

            if (comboObjectives != null)
            {
                comboObjectives.LogObjectives();
                comboObjectives.WriteActions();
                _tacticeService.UpdateObjectives();
                continue;
            }

            Console.Error.WriteLine($"Did not find comboObjectives going to wait.");
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Console.WriteLine(Actions.WAIT());

            // WAIT | LINE <sourceIdx> <targetIdx> <strength> | BEACON <cellIdx> <strength> | MESSAGE <text>

        }
    }


}