namespace CSGO
{
    [GunName("GlükGlük")]
    public class Glock17 : Silah, IAtesEdebilable
    {
          public Glock17()
        {
   
            this.range = 160;
            this.damage = 55;
        }

        public override string ToString()
        {
            return base.ToString();
        }


        public string AtesEt()
        {
            return " Gun fired  with Damage of " + this.damage + " and range of " + this.range + " Maşallah";
        }
    }
}
