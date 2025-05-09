using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Rendering;
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

        Debug.Log("Hai Colpito");
        return true;

    }

    public static bool IsCrit(int critValue)
    {

        if (Random.Range(0, 99) < critValue)
        {

            Debug.Log("CRIT!");
            return true;
        }

        return false;

    }

    public static void CalculateDebuf(ELEMENT attackerelement, Hero defender)
    {

        Stats DebuffedStats = defender.GetBaseStats();

        switch (attackerelement)
        {
            case ELEMENT.ICE:

                Debug.Log($"{defender} it's freez");
                Stats debuffedStats = defender.GetBaseStats();
                debuffedStats.spd = debuffedStats.spd - 1;
                defender.SetBaseStats(debuffedStats);


                break;

            case ELEMENT.FIRE:

                Debug.Log($"{defender} it's burnt");
                int debuffedhp = defender.GetHp();
                debuffedhp -= 1;
                defender.SetHp(debuffedhp);

                break;

            case ELEMENT.LIGHTNING:

                Debug.Log($"{defender} it's blind");
                Stats debuffedstats = defender.GetBaseStats();
                debuffedstats.aim = debuffedstats.aim - 1;
                defender.SetBaseStats(debuffedstats);

                break;

            default:
                break;

        }
    }

    public static bool ItDebuffed(Hero attacker)
    {

        if (IsCrit(attacker.GetBaseStats().crt))
        {

            return true;

        }

        return false;

    }



    public static int CalculateDamage(Hero attacker, Hero defender)
    {

        int atk = attacker.GetBaseStats().atk + attacker.GetWeapon().GetBonusStats().atk;
        int def = attacker.GetBaseStats().def + attacker.GetWeapon().GetBonusStats().def;
        int res = attacker.GetBaseStats().res + attacker.GetWeapon().GetBonusStats().res;
        int spd = attacker.GetBaseStats().spd + attacker.GetWeapon().GetBonusStats().spd;
        int crt = attacker.GetBaseStats().crt + attacker.GetWeapon().GetBonusStats().crt;
        int aim = attacker.GetBaseStats().aim + attacker.GetWeapon().GetBonusStats().aim;
        int eva = attacker.GetBaseStats().eva + attacker.GetWeapon().GetBonusStats().eva;

        switch (attacker.GetWeapon().GetdmgTyp())
        {

            case Weapon.DAMAGE_TYPE.PHYSICAL:
                def = defender.GetBaseStats().def;
                break;
            case Weapon.DAMAGE_TYPE.MAGICAL:
                def = defender.GetBaseStats().res;
                break;

        }

        float dmg = (atk - def);

        dmg *= EvaluateElementalModifier(attacker.GetWeapon().Getelm(), defender);

        if (IsCrit(attacker.GetBaseStats().crt)) { dmg *= 2; }

        return (dmg >= 0) ? (int)dmg : 0;



    }

}
