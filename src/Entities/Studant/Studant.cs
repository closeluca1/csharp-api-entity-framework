namespace Entities.Studant;

public class Studant
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    public bool isActive { get; private set; }

    public Studant(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        isActive = true;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void Desactive()
    {
        isActive = false;
    }

    public void Active()
    {
        isActive = true;
    }
}