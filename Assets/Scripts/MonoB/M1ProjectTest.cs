using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] Hero A;
    [SerializeField] Hero B;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

        Stats statsA = new Stats(10, 5, 7, 4, 3, 4, 6);
        Stats statsweaponA = new Stats(1, 0, 2, 0, 4, 2, 0);
        Weapon weaponA = new Weapon("Spada", Weapon.DAMAGE_TYPE.PHYSICAL, ELEMENT.NONE, statsweaponA);
        A = new Hero("Aragorn", 100, statsA, ELEMENT.ICE, ELEMENT.FIRE, weaponA);


        Stats statsB = new Stats(10, 5, 7, 4, 3, 4, 6);
        Stats statsweaponB = new Stats(5, 2, 0, 0, 2, 0, 0);
        Weapon weaponB = new Weapon("Bastone", Weapon.DAMAGE_TYPE.MAGICAL, ELEMENT.LIGHTNING, statsweaponB);
        B = new Hero("Gandalf", 200, statsB, ELEMENT.LIGHTNING, ELEMENT.NONE, weaponB);

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 1f)
        {

        


            int spdtotA = A.GetBaseStats().spd + A.GetWeapon().GetBonusStats().spd;
            int spdtotB = B.GetBaseStats().spd + B.GetWeapon().GetBonusStats().spd;




            if (spdtotA > spdtotB)

            {

                Combact(A, B);
                if (B.IsAlive()) { Combact(B, A); }

            }

            else
            {

                Combact(B, A);
                if (B.IsAlive()) { Combact(A, B); }
  

            }

            timer = 0f;

        }

    }

    public void Combact(Hero attacker, Hero defender)
    {


        if (!attacker.IsAlive() || !defender.IsAlive()) { return; }

        Debug.Log($"<color=white>Attacca : { attacker.GetName() }</color> <color=blue>  Difende : { defender.GetName()} </color>");


        if (GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats()))
        {

            if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().Getelm(), defender))
            {

                Debug.Log("<color=red> RESIST!!! </color>");
             

            }

            else if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().Getelm(), defender))
            {

                Debug.Log("<color=green> WEAK!!! </color>");

            }

            else { }

            int damage = GameFormulas.CalculateDamage(attacker, defender);

            defender.TakeDamage(damage);

            Debug.Log( $"{defender.GetName()} subisce <color=red>{damage} danni!</color> <color=green> HP rimanenti:  {defender.GetHp()}</color>");


            if (defender.IsAlive()) { return; }

            else
            {

                Debug.Log($"<color=red>***** {defender.GetName()} E' MORTO *****</color>");
                Debug.Log($"<color=magenta>***** COMBATTIMENTO TERMINATO *****</color>");
                string winner = A.IsAlive() ? A.GetName() : B.GetName();
                Debug.Log($"<color=cyan>Vincitore: {winner}</color>");

            }

        }

        else { Debug.Log("attacco mancato"); }

    }

}




