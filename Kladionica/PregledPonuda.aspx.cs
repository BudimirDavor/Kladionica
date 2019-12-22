using Kladionica.Core;
using System;

namespace Kladionica
{
    public partial class PregledPonuda : System.Web.UI.Page
    {
        private readonly IPonudaRepository _ponudaRepository;

        public PregledPonuda()
        {
            _ponudaRepository = PonudaRepositoryFactory.Create();
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
            var domacin = domacinSearchTextBox.Text.Trim();
            var gost = gostSearchTextBox.Text.Trim();
            var tip = tipSearchDropDownList.SelectedValue;
            var koeficient = koeficientSearchTextBox.Text.Trim();

            var ponude = _ponudaRepository.GetPonudasWithSusret(domacin, gost, tip, koeficient);

            ponudeRepeater.DataSource = ponude;
            ponudeRepeater.DataBind();
        }
    }
}