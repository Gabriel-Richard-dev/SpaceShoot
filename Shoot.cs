namespace SpaceShoot;

public class Shoot
{
    public Shoot(Tabuleiro tab, SpaceShooter? spc = null, SpaceVillain? vl = null)
    {   
        if (spc is not null)
        {
            position = new int[2];
            position[(int)Posicao.Horizontal] = spc.position[(int)Posicao.Horizontal];
            position[(int)Posicao.Vertical] = spc.position[(int)Posicao.Vertical] - 1;
        }
        else
        {
            position = new int[2];
            position[(int)Posicao.Horizontal] = vl.position[(int)Posicao.Horizontal];
            position[(int)Posicao.Vertical] = vl.position[(int)Posicao.Vertical] + 1;
        }
    }
    public int[] position { get; set; }
    public readonly string ShootDraw = "॰";

    public void Projetil(int num)
    {
        position[1] += num;
    }
    
}