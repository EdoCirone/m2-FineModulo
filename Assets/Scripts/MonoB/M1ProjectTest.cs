
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

        //Stats statsA = new Stats(5, 3, 3, 4, 3, 4, 6);
        //Stats statsweaponA = new Stats(1, 0, 2, 10, 4, 2, 0);

        //Weapon weaponA = new Weapon("Spada", Weapon.DAMAGE_TYPE.PHYSICAL, ELEMENT.NONE, statsweaponA);
        //A = new Hero;


        //Stats statsB = new Stats(3, 2, 3, 3, 3, 5, 3);
        //Stats statsweaponB = new Stats(5, 2, 0, 10, 2, 0, 0);

        //Weapon weaponB = new Weapon("Bastone", Weapon.DAMAGE_TYPE.MAGICAL, ELEMENT.LIGHTNING, statsweaponB);
        //B = new Hero;

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
                if (B.GetIsAlive()) { Combact(B, A); }

            }

            else
            {

                Combact(B, A);
                if (B.GetIsAlive()) { Combact(A, B); }


            }

            timer = 0f;

        }

    }

    public void Combact(Hero attacker, Hero defender)
    {

        if (!attacker.GetIsAlive() || !defender.GetIsAlive()) { return; }

        int attackerCrit = attacker.GetBaseStats().crt + attacker.GetWeapon().GetBonusStats().crt;


        Debug.Log($"<color=white>Attacca : {attacker.Name}</color> <color=blue>  Difende : {defender.Name} </color>");


        if (GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats()))
        {

            //GameFormulas.CalculateDebuff(attacker.GetWeapon().Getelm(), defender, didCrit);
            bool didCrit = GameFormulas.IsCrit(attackerCrit);
            int damage = GameFormulas.CalculateDamage(attacker, defender, didCrit);

            if (didCrit)
            {
                Debug.Log("<color=yellow>CRIT!</color>");
            }


            if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().Getelm(), defender))
            {

                Debug.Log("<color=red> RESIST!!! </color>");


            }

            else if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().Getelm(), defender))
            {

                Debug.Log("<color=green> WEAK!!! </color>");

            }

            else { }

            defender.TakeDamage(damage);

            Debug.Log($"{defender.Name} subisce <color=red> {damage} danni!</color> <color=green> HP rimanenti:  {defender.Hp}</color>");


            if (defender.GetIsAlive()) { return; }

            else
            {

                Debug.Log($"<color=red>***** {defender.Name} E' MORTO *****</color>");
                Debug.Log($"<color=magenta>***** COMBATTIMENTO TERMINATO *****</color>");
                string winner = A.GetIsAlive() ? A.Name : B.Name;
                Debug.Log($"<color=cyan>Vincitore: {winner}</color>");

            }

        }

        else { Debug.Log("attacco mancato"); }

    }

}




