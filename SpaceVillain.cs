using Random = System.Random;

namespace SpaceShoot;

public class SpaceVillain
{
    public SpaceVillain()
    {
        Random rand = new Random();
        life = 2;
        villainDraw = "\u25bc";
        position = new int[2];
        position[(int)Posicao.Horizontal] = rand.Next()  % 59 + 1;
        position[(int)Posicao.Vertical] = rand.Next() % 10 + 1;
    }

    public string villainDraw { get; set; }
    public int[] position { get; set; }
    public List<Shoot> vlshoots = new List<Shoot>();
    public int life { get; set; }

    public void Move(Tabuleiro tab)
    {
        var rand = new Random();
        ConsoleKey? movement = null;
        if ((rand.Next() % 10) % 3 == 0)
        {
            List<ConsoleKey> keys = new List<ConsoleKey>()
            {
                ConsoleKey.UpArrow, ConsoleKey.DownArrow,
                ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.Spacebar
            };
            var prob = new Random();
            int space = 0;
            if ((prob.Next() % 100) % 7 == 0)
            {
                space = 1;
            }

            movement = keys[(rand.Next() % 4 + space)];
        }

        switch (movement)
        {
            case ConsoleKey.UpArrow:
            {
                if(position[(int)Posicao.Vertical] - 1 > 0) {
                    position[(int)Posicao.Vertical]--;
                }
            } break;
            case ConsoleKey.DownArrow:  
                if(position[(int)Posicao.Vertical] - 1 <= 10) {
                    position[(int)Posicao.Vertical]++;
                } break;
            case ConsoleKey.LeftArrow: 
                if(position[(int)Posicao.Horizontal] - 1 > 1) {
                    position[(int)Posicao.Horizontal]--;
                } break;
            case ConsoleKey.RightArrow:
                if(position[(int)Posicao.Horizontal] + 1 < 60) {
                    position[(int)Posicao.Horizontal]++;
                } break;
            case ConsoleKey.Spacebar:
            {
                Shoot shoot = new Shoot(tab, null, this);
                vlshoots.Add(shoot);
                    
            } break;
            
            case null: break;
                
        }

        tab.InsereTiro(vlshoots, tab);
        vlshoots = tab.AtualizaTiros(vlshoots, +1);
    }
}