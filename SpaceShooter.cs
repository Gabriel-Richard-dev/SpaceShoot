namespace SpaceShoot;

public class SpaceShooter
{
    public SpaceShooter()
    {
        position = new int[2];
        position[(int)Posicao.Horizontal] = 29;
        position[(int)Posicao.Vertical] = 18;
    }
    
    public int[] position { get; set; }
    public readonly string NaveDraw = "\u25b2";
    private ConsoleKey key;
    public List<Shoot> shoots = new List<Shoot>();
    public ConsoleKey Move(Tabuleiro tab, ConsoleKey? key)
    {
        if (Console.KeyAvailable)
        {
            var keyhash = Console.ReadKey(true).Key;
            key = keyhash;
        }
        Thread.Sleep(100);
        switch (key)
        {
            case ConsoleKey.UpArrow:
            {
                if(position[(int)Posicao.Vertical] - 1 >= 10) {
                    position[(int)Posicao.Vertical]--;
                }
            } break;
            case ConsoleKey.DownArrow:  
                if(position[(int)Posicao.Vertical] + 1 <= 20) {
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
                Shoot shoot = new Shoot(tab, this, null);
                shoots.Add(shoot);
                    
            } break;
            case null: break;
        }

            tab.InsereTabuleiro(this, shoots);
            tab.InsereTiro(shoots, tab);
            shoots = tab.AtualizaTiros(shoots, -1);

            if (Console.KeyAvailable)
            {
                return Console.ReadKey(true).Key;
            }

            if (key is not null && !(key.Equals(ConsoleKey.Spacebar)))
            {
                return (ConsoleKey)key;
            }
            else
            {
                return ConsoleKey.F1;
            }
            
    }
    
}

