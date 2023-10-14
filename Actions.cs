using SpaceShoot.ModelAction;

namespace SpaceShoot;
public class Actions
{
    public ActionModel Colisoes(List<SpaceVillain> villains, SpaceShooter spc)
    {
        var viloesRemoved = new List<SpaceVillain>();
        var shootsRemoved = new List<Shoot>();
        var vlshootRemoved = new List<List<Object>>();
        
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
                        spc.Points += 50;
                        viloesRemoved.Add(vilian);
                        shootsRemoved.Add(shoot);
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
                if (vlshoot.position[(int)Posicao.Vertical] == spc.position[(int)Posicao.Vertical]
                    && vlshoot.position[(int)Posicao.Horizontal] == spc.position[(int)Posicao.Horizontal])
                {
                    spc.NaveDraw = "\u25b3";
                    spc.Vida -= 1;
                }
                
                
                foreach (var shoot in spc.shoots)
                {
                    if (shoot.position[(int)Posicao.Horizontal] == vlshoot.position[(int)Posicao.Horizontal]
                        && shoot.position[(int)Posicao.Vertical] == vlshoot.position[(int)Posicao.Vertical])
                    {
                        shootsRemoved.Add(shoot);
                        vlshootRemoved.Add(new List<object>() {villian, vlshoot});
                    }

                }   
            }
        }

        foreach (List<object> rmvlsht in vlshootRemoved)
        {
            foreach (var vilian in villains)
            {
                if (vilian.Equals(rmvlsht[0]))
                {
                    vilian.vlshoots.Remove((Shoot)rmvlsht[1]);
                }
            }
        }

        foreach (var rmvl in viloesRemoved)
        {
            villains.Remove(rmvl);
        }

        foreach (var rmsht in shootsRemoved)
        {
            spc.shoots.Remove(rmsht);
        }

        var hash = ColideTiro(villains, spc);
        spc = (SpaceShooter)hash.actions[0];
        villains = (List<SpaceVillain>)hash.actions[1];
        
        return new ActionModel(spc, villains);

    }

    public ActionModel ColideTiro(List<SpaceVillain> villains, SpaceShooter spc)
    {
        var shootsRemoved = new List<Shoot>();
        var vlshootsRemoved = new List<List<object>>();
        
        
        foreach (var villian in villains)
        {
            foreach (var vlshoot in villian.vlshoots)
            {
                foreach (var shoot in spc.shoots)
                {
                    if (vlshoot.position[(int)Posicao.Horizontal] == shoot.position[(int)Posicao.Horizontal]
                        && vlshoot.position[(int)Posicao.Vertical] == shoot.position[(int)Posicao.Vertical])
                    {
                        shootsRemoved.Add(shoot);
                        vlshootsRemoved.Add(new List<object>() {villian, shoot});
                    }
                }
            }
            
        }

        foreach (var rmshoot in shootsRemoved)
        {
            spc.shoots.Remove(rmshoot);
        }

        foreach (List<object> rmvlsht in vlshootsRemoved)
        {
            foreach (var vilian in villains)
            {
                if (vilian.Equals(rmvlsht[0]))
                {
                    vilian.vlshoots.Remove((Shoot)rmvlsht[1]);
                }
            }
        }

        return new ActionModel(spc, villains);
        
    }

}