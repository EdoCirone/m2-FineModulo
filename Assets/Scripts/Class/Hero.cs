
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
        this.name = "Aragorn";
        this.hp = 200;
        this.baseStats = new Stats(5, 6, 3, 4, 2, 1, 5);
        this.resistance = ELEMENT.FIRE;
        this.weakness = ELEMENT.ICE;
        this.Weapon = new Weapon("Spada", Weapon.DAMAGE_TYPE.PHYSICAL, ELEMENT.NONE, new Stats(1, 0, 2, 10, 4, 2, 0));
    }



    public void AddHp(int ammount)
    {
        Hp = (hp + ammount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive() => hp > 0;

    //public void DebuffTime()
    //{

    //    if (!Debuffed) { return; }

    //    timer--;

    //    if (timer <= 0)
    //    {
    //        Debug.Log($" {name} Debuff finish");
    //        Debuffed = false;
    //    }


    //}

    //public void ResetDebuffTime()
    //{
    //    timer = 3;
    //}

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

    //public bool GetDebuffed() => Debuffed;
    //public void SetDebuffed(bool Debuffed) { this.Debuffed = Debuffed; }

    public Weapon GetWeapon() => Weapon;
    public void SetWeapon(Weapon weapon) { this.Weapon = weapon; }

}

