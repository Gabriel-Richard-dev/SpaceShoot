using SpaceShoot.ModelAction;

namespace SpaceShoot;
public class Actions
{
    public ActionModel Colisoes(List<SpaceVillain> villains, SpaceShooter spc)
    {
        
        foreach (var shoot in spc.shoots)
        {
            foreach (var vilian in villains)
            {
                if (shoot.position[(int)Posicao.Horizontal] == vilian.position[(int)Posicao.Horizontal]
                    && shoot.position[(int)Posicao.Vertical] == vilian.position[(int)Posicao.Vertical])
                {
                    vilian.villainDraw = "\u25bd";
                    if (vilian.life == 0)
                    {
                        villains.Remove(vilian);
                        spc.shoots.Remove(shoot);
                    }
                    else
                    {
                        vilian.life--;
                    }

                }
            }
            
        }


        foreach (var villian in villains)
        {
            foreach (var vlshoot in villian.vlshoots)
            {
                foreach (var shoot in spc.shoots)
                {
                    if (shoot.position[(int)Posicao.Horizontal] == vlshoot.position[(int)Posicao.Horizontal]
                        && shoot.position[(int)Posicao.Vertical] == vlshoot.position[(int)Posicao.Vertical])
                    {
                        spc.shoots.Remove(shoot);
                        villian.vlshoots.Remove(vlshoot);
                    }

                }   
            }
        }
        
        
        return new ActionModel(spc, villains);

    }

    public void ColideTiro(List<SpaceVillain> villains, List<Shoot> spcShoot)
    {
        
    }
    
    
}