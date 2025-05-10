
using Unity.VisualScripting;
using UnityEngine;

public static class GameFormulas
{

    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {

        return (attackElement == defender.GetWeakness());

    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {

        return (attackElement == defender.GetResistance());

    }



    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {

        if (HasElementAdvantage(attackElement, defender)) { return 1.5f; }

        if (HasElementDisadvantage(attackElement, defender)) { return 0.5f; }

        return 1f;

    }

    public static bool HasHit(Stats attacker, Stats defender)
    {

        int hitChance = defender.eva - attacker.aim;

        if (Random.Range(0, 99) < hitChance)
        {

            Debug.Log("Miss");
            return false;

        }

        Debug.Log("Colpito");
        return true;

    }

    public static bool IsCrit(int critValue)
    {

        if (Random.Range(0, 100) < critValue)
        {

            Debug.Log("<color=yellow>CRIT!</color>");
            return true;

        }

        return false;

    }

    //public static void CalculateDebuff(ELEMENT attackerelement, Hero defender, bool isCrit)
    //{
    //    defender.DebuffTime();

    //    if (defender.GetDebuffed()) return;

    //    if (!isCrit) return;

    //    {
    //        Stats DebuffedStats = defender.GetBaseStats();

    //        switch (attackerelement)

    //        {
    //            case ELEMENT.ICE:

    //                Debug.Log($"{defender.Name} it's freez");
    //                DebuffedStats.spd = DebuffedStats.spd - 1;
    //                defender.SetBaseStats(DebuffedStats);
    //                defender.SetDebuffed(true);
    //                //defender.ResetDebuffTime();
    //                break;

    //            case ELEMENT.FIRE:

    //                Debug.Log($"{defender.Name} is burnt");
    //                defender.Hp -= 1;
    //                defender.SetDebuffed(true);
    //                //defender.ResetDebuffTime();
    //                break;

    //            case ELEMENT.LIGHTNING:

    //                Debug.Log($"{defender.Name} it's blind");
    //                DebuffedStats.aim = DebuffedStats.aim - 1;
    //                defender.SetBaseStats(DebuffedStats);
    //                defender.SetDebuffed(true);
    //                //defender.ResetDebuffTime();
    //                break;

    //            default:
    //                break;

    //        }
    //    }

    //}





    //public static bool IsDebuff(Hero hero)
    //{

    //    return !hero.GetDebuffed() && IsCrit(hero.GetBaseStats().crt);

    //}



    public static int CalculateDamage(Hero attacker, Hero defender, bool isCrit)
    {



        Stats Somma = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetBonusStats());

        int def = 0;

        switch (attacker.GetWeapon().GetdmgTyp())
        {

            case Weapon.DAMAGE_TYPE.PHYSICAL:
                def = defender.GetBaseStats().def + defender.GetWeapon().GetBonusStats().def;
                break;

            case Weapon.DAMAGE_TYPE.MAGICAL:
                def = defender.GetBaseStats().res + defender.GetWeapon().GetBonusStats().res;
                break;
        }


        float dmg = (Somma.atk - def);

        dmg *= EvaluateElementalModifier(attacker.GetWeapon().Getelm(), defender);

        if (isCrit) { dmg *= 2; }
        ;

        return (dmg >= 0) ? (int)dmg : 0;



    }

}
