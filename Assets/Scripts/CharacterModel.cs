using System;

public class CharacterModel
{
    public event Action onChanged;

    private string name;
    private string description;
    private string imagePath;

    public string Name 
    { 
        get 
        { 
            return name; 
        }
        set 
        {
            if (name != value)
                onChanged?.Invoke();
            name = value; 
        } 
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            if (description != value)
                onChanged?.Invoke();
            description = value;
        }
    }
    public string ImagePath
    {
        get
        {
            return imagePath;
        }
        private set
        {
            imagePath = value;
        }
    }
    public CharacterModel(string name, string description, string imagePath)
    {
        this.name = name;
        this.description = description;
        this.imagePath = imagePath;

        onChanged?.Invoke();
    }

}
