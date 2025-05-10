
using UnityEngine;

[System.Serializable]

public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon Weapon;
    //[SerializeField] private bool Debuffed;
    //[SerializeField] private int timer = 3;



    public Hero (string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon Weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.Weapon = Weapon;
    }



    private void AddHp(int ammount)
    {
        Hp = (hp + ammount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    private bool IsAlive() => hp > 0;

    //GET SET


    public void SetName(string name) { this.name = name; }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public Stats GetBaseStats() => baseStats;
    public void SetBaseStats(Stats baseStats) { this.baseStats = baseStats; }

    public ELEMENT GetResistance() => resistance;
    public void SetResistance(ELEMENT resistance) { this.resistance = resistance; }

    public ELEMENT GetWeakness() => weakness;
    public void SetWeakness(ELEMENT weakness) { this.weakness = weakness; }
    public Weapon GetWeapon() => Weapon;
    public void SetWeapon(Weapon weapon) { this.Weapon = weapon; }

    public bool GetIsAlive() => IsAlive();
}

