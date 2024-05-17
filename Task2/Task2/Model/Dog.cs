namespace Task2.Model;

public class Dog : Animal, IVoicalizable
{
    public event EventHandler<string> Voice;

    public override bool Accelerate()
    {
        if (Speed < maxSpeed)
        {
            Speed += 10;
            return true;
        }
        return false;
    }

    public string OnVocalize()
    {
        Voice?.Invoke(this, "Dog barks!");
        return "Dog barks!";
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