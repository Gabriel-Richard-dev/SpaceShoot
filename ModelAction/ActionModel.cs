namespace SpaceShoot.ModelAction;

public class ActionModel
{
    public ActionModel() { }

    public ActionModel(SpaceShooter spc, List<SpaceVillain> spaceVillain)
    {
        actions.Clear();
        actions.Add(spc);
        actions.Add(spaceVillain);
    }
    
    public List<Object> actions = new List<Object>();
    
}