using System;

namespace Kladionica.Core.UIModel
{
    public class Listic
    {
        public long ListicId { get; set; }
        public DateTime VrijemeUplate { get; set; }
        public double IznosUplate { get; set; }
        public double? MoguciDobitak { get; set; }
        public int BrojOklada { get; set; }
        public DateTime? UpdateDate { get; set; }

        public override string ToString()
        {
            var text = $"{VrijemeUplate} (Iznos: {IznosUplate:c}, Mogući dobitak:";

            return MoguciDobitak.HasValue ? $"{text} {MoguciDobitak:c})" : $"{text} ?)";
        }
    }
}