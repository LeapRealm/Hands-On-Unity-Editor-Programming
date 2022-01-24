using System;

public enum PlayerClass
{
    Warrior,
    Magician
}

[Serializable]
public class PlayerData
{
    public int hp;
    public string name;
    public PlayerClass playerClass;
}