namespace Task2.Model;

public class Panther : Animal, IVoicalizable
{
    public event EventHandler<string> Voice;
    public event EventHandler<string> ClimbTree;

    public override bool Accelerate()
    {
        if (Speed < maxSpeed)
        {
            Speed += 20;

            return true;
        }
        return false;
    }

    public override bool Decelerate()
    {
        if (Speed > minSpeed)
        {
            Speed -= 20;

            return true;
        }
        return false;
    }

    public string OnClimbTree()
    {
        ClimbTree?.Invoke(this, "Panther climbed the tree!");
        return "Panther climbed the tree!";
    }

    public string OnVocalize()
    {
        Voice?.Invoke(this, "Panther roars!");
        return "Panther roars!";
    }
}
