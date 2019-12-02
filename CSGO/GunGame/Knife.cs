namespace CSGO
{
    public class Knife : Silah , ISavurabilable
    {

        public Knife()
        {
            this.range = 2;
            this.damage = 45;
        }

        public string Savur()
        {
            return " Gun savurdu with Damage of " + this.damage + " and range of " + this.range + " Maşallah";

        }
    }
}
