using Kladionica.Core;
using System;

namespace Kladionica
{
    public partial class PregledOklada : System.Web.UI.Page
    {
        private readonly IOkladaRepository _okladaRepository;

        public PregledOklada()
        {
            _okladaRepository = OkladaRepositoryFactory.Create();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Search();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var vrijemeUplate = vrijemeUplateSearchTextBox.Text.Trim();
            var iznosUplate = iznosUplateSearchTextBox.Text.Trim();
            var moguciDobitak = moguciDobitakTextBox.Text.Trim();
            var koeficient = koeficientSearchTextBox.Text.Trim();

            var ponude = _okladaRepository.GetOkladasWithListic(vrijemeUplate, 
                iznosUplate, moguciDobitak, koeficient);

            okladeRepeater.DataSource = ponude;
            okladeRepeater.DataBind();
        }
    }
}