using System;
using System.Runtime.InteropServices.ComTypes;
using SpaceShoot.ModelAction;

namespace SpaceShoot;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        var spaceship = new SpaceShooter();
        var action = new Actions();
        var actionmodel = new ActionModel();
        List<SpaceVillain> spaceVillains = new List<SpaceVillain>();
        spaceVillains.Add(new SpaceVillain());
        var tab = new Tabuleiro();
        ConsoleKey? key = null;
        tab.InsereTabuleiro(spaceship, null);
        tab.InsereNave(spaceship);

        while (true)
        {
            key = spaceship.Move(tab, key);
            actionmodel = action.Colisoes(spaceVillains, spaceship);
            gerenciaVilao(tab, spaceVillains);
            spaceship = (SpaceShooter)actionmodel.actions[(int)Entity.Spaceship];
            spaceVillains = (List<SpaceVillain>)actionmodel.actions[(int)Entity.Spacevillain];
        }
        
    }
    
    public static void gerenciaVilao(Tabuleiro tb, List<SpaceVillain> vilans)
    {
        
        tb.InsereVillians(vilans);

        foreach (var vl in vilans)
        {
            vl.Move(tb);
        }
       
    }
}



public enum Posicao{ Horizontal, Vertical }

public enum Entity { Spaceship, Spacevillain}