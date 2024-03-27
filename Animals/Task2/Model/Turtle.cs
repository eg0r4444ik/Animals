namespace Task2.Model;

public class Turtle : Animal
{
    public override bool Accelerate()
    {
        if (Speed < maxSpeed)
        {
            Speed += 5;
            return true;
        }
        return false;
    }

    public override bool Decelerate()
    {
        if (Speed > minSpeed)
        {
            Speed -= 5;
            return true;
        }
        return false;
    }
}