
using UnityEngine;

[System.Serializable]

public class Weapon
{
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elm;
    [SerializeField] private Stats bonusStats;

    public Weapon( string name, DAMAGE_TYPE dmgType, ELEMENT elm, Stats bonusStats)
    {
        this.name = "Martello";
        this.dmgType = DAMAGE_TYPE.PHYSICAL;
        this.elm = ELEMENT.ICE;
        this.bonusStats =  bonusStats;
    }

    public string Getname() => name; 
    public void Setname( string name) { this.name = name; }

    public DAMAGE_TYPE GetdmgTyp() => dmgType; 
    public void SetdmgType(DAMAGE_TYPE dmgType) { this.dmgType = dmgType; }

    public ELEMENT Getelm() => elm;
    public void Setelm(ELEMENT elm) { this.elm = elm; }

    public Stats GetBonusStats() => bonusStats;
    public void SetBonusStats(Stats bonusStats)  { this.bonusStats = bonusStats; }




}
