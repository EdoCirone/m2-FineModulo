[System.Serializable]
public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {

        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;

    }

    public static Stats Sum(Stats stats, Stats stats2)
    {


        return new Stats
        {

            atk = stats.atk + stats2.atk,
            def = stats.def + stats2.def,
            res = stats.res + stats2.res,
            spd = stats.spd + stats2.spd,
            crt = stats.crt + stats2.crt,
            aim = stats.aim + stats2.aim,
            eva = stats.eva + stats2.eva,

        };



    }

}


