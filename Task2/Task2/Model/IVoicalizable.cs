namespace Task2.Model;

public interface IVoicalizable
{
    event EventHandler<string> Voice;
    string OnVocalize();
}
