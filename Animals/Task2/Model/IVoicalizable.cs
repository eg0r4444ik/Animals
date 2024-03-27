namespace Task2.Model;

public interface IVoicalizable
{
    event EventHandler Voice;
    void OnVocalize();
}
