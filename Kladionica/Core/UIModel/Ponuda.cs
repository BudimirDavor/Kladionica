namespace Kladionica.Core.UIModel
{
    public class Ponuda
    {
        public long PonudaId { get; set; }
        public long SusretId { get; set; }
        public string Tip { get; set; }
        public double Koeficient { get; set; }
        public string Susret { get; set; }

        public string Description 
        { 
            get { return $"{Susret} (Tip: {Tip})"; }
        }
    }
}