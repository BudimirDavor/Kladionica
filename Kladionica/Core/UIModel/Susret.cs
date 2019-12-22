namespace Kladionica.Core.UIModel
{
    public class Susret
    {
        public long SusretId { get; set; }
        public string Domacin { get; set; }
        public string Gost { get; set; }
        public int BrojPonuda { get; set; }

        public override string ToString()
        {
            return $"{Domacin} - {Gost}";
        }
    }
}