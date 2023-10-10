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

        while (!(spaceship.Morreu()) || (spaceship.Ganhou()))
        {
            key = spaceship.Move(tab, key);
            actionmodel = action.Colisoes(spaceVillains, spaceship);
            gerenciaVilao(tab, spaceVillains);
            spaceship = (SpaceShooter)actionmodel.actions[(int)Entity.Spaceship];
            spaceVillains = (List<SpaceVillain>)actionmodel.actions[(int)Entity.Spacevillain];
        }
        
        Final(spaceship);
        
    }
    
    public static void gerenciaVilao(Tabuleiro tb, List<SpaceVillain> vilans)
    {
        
        tb.InsereVillians(vilans);

        foreach (var vl in vilans)
        {
            vl.Move(tb);
        }
       
    }

    public static void Final(SpaceShooter spc)
    {
        if (spc.Morreu())
        {
            Console.Write("Você morreu!");
            Console.ReadLine();
        }else if (spc.Ganhou())
        {
            Console.Write("Você ganhou!");
        }
    }
}



public enum Posicao{ Horizontal, Vertical }

public enum Entity { Spaceship, Spacevillain}