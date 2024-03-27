namespace Task2.Model;

public class Panther : Animal, IVoicalizable
{
    public event EventHandler Voice;
    public event EventHandler ClimbTree;

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

    public void OnClimbTree()
    {
        ClimbTree?.Invoke(this, EventArgs.Empty);
    }

    public void OnVocalize()
    {
        Voice?.Invoke(this, EventArgs.Empty);
    }
}
