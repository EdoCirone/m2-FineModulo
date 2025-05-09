using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Hero
{
    [SerializeField]private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon Weapon;
    [SerializeField] private bool Debbufed;

    public Hero (string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon Weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.Weapon = Weapon;
    }



    public void AddHp(int ammount)
    {
        SetHp(hp + ammount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive() => hp > 0;


    public string GetName()=> name;
    public void SetName(string name) { this.name = name;}
   
    public int GetHp() => hp;
    public void SetHp(int hp) { this.hp = hp;}

    public Stats GetBaseStats() => baseStats;
    public void SetBaseStats(Stats baseStats) { this.baseStats = baseStats;}

    public ELEMENT GetResistance() => resistance;
    public void SetResistance(ELEMENT resistance) { this.resistance = resistance;}

    public ELEMENT GetWeakness() => weakness;
    public void SetWeakness( ELEMENT weakness ) { this.weakness = weakness;}

    public Weapon GetWeapon() => Weapon;
    public void SetWeapon(Weapon weapon) { this.Weapon = weapon;}

}

