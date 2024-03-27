namespace Task2.Model;

public class Dog : Animal, IVoicalizable
{
    public event EventHandler Voice;

    public override bool Accelerate()
    {
        if (Speed < maxSpeed)
        {
            Speed += 10;
            return true;
        }
        return false;
    }

    public void OnVocalize()
    {
        Voice?.Invoke(this, EventArgs.Empty);
    }

    public override bool Decelerate()
    {
        if (Speed > minSpeed)
        {
            Speed -= 10;
            return true;
        }
        return false;
    }
}