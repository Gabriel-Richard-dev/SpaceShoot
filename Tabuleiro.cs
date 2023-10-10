using System.Transactions;

namespace SpaceShoot;

public class Tabuleiro
{
    public void InsereTabuleiro(SpaceShooter spcship, List<Shoot> sht)
    {
        Console.Clear();
        Console.CursorVisible = false;
        for (int i = 0; i < 61; i++)
        {
            Console.Write("#");
        }
        
        Console.Write("\n");

        for (int linha = 0; linha < 20; linha++)
        {
            for (int j = 0; j < 61; j++)
            {
                if (j == 0 || j == 60)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(" ");
                }
                
            }
            Console.Write("\n");
        }
        for (int i = 0; i < 61; i++)
        {
            Console.Write("#");
        }
        
        Console.Write("\n");
        InsereNave(spcship);
        
    }
    
    public void InsereNave(SpaceShooter spcship)
    {
        
        Console.SetCursorPosition(spcship.position[(int)Posicao.Horizontal], spcship.position[(int)Posicao.Vertical]);
        Console.Write(spcship.NaveDraw);
        Console.SetCursorPosition(0, 24);
        Console.Write($"{spcship.Vida} | {spcship.Points}");

    }

    public void InsereTiro(List<Shoot> sht, Tabuleiro tab)
    {
        foreach (var st in sht)
        {
            Console.SetCursorPosition(st.position[(int)Posicao.Horizontal], st.position[(int)Posicao.Vertical]);
            Console.Write(st.ShootDraw);
            Console.SetCursorPosition(0, 24);
        } 
    }

    public void InsereVillians(List<SpaceVillain> vls)
    {
        Random rand = new Random();
        if ((rand.Next() % 100) % 99 == 0 && vls.Count < 5)
        {
            vls.Add(new SpaceVillain());
        } 
        foreach (var v in vls)
        {
            Console.SetCursorPosition(v.position[(int)Posicao.Horizontal], v.position[(int)Posicao.Vertical]);
            Console.Write(v.villainDraw);
            Console.SetCursorPosition(0, 24);    
        }
        
    }
    public List<Shoot> AtualizaTiros(List<Shoot> sht, int num)
    {   
        foreach (var st in sht)
        {
            switch (num)
            {
                case 1:
                {
                    if ((st.position[(int)Posicao.Vertical] - 1) == -1)
                    {
                        continue;
                    }
                    st.Projetil(+1);
                } break;
                case -1:
                {
                    if ((st.position[(int)Posicao.Vertical] + 1) == 22)
                    {
                        continue;
                    }
                    st.Projetil(-1);
                } break;
            }
            
        }

        switch (num)
        {
            case 1:
            {
                
                for (int s = 0; s < (sht.Count()); s++)
                {
                    if (sht[s].position[(int)Posicao.Vertical] == 21)
                    {
                        sht.Remove(sht[s]);
                    }
                }
            }
                break;
            case -1:
            {
                
                for (int s = 0; s < (sht.Count()); s++)
                {
                    if (sht[s].position[(int)Posicao.Vertical] == 0)
                    {
                        sht.Remove(sht[s]);
                    }
                }
            } break;
        }

        return sht;
    }

}

    


