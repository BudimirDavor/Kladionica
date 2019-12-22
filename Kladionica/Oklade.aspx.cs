using Kladionica.Core;
using log4net;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Kladionica
{
    public partial class Oklade : System.Web.UI.Page
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Oklade));
        private readonly IListicRepository _listicRepository;
        private readonly IPonudaRepository _ponudaRepository;
        private readonly IOkladaRepository _okladaRepository;

        public Oklade()
        {
            _listicRepository = ListicRepositoryFactory.Create();
            _ponudaRepository = PonudaRepositoryFactory.Create();
            _okladaRepository = OkladaRepositoryFactory.Create();
        }

        private long ListicId
        {
            get { return Convert.ToInt64(ViewState["ListicId"]); }
            set { ViewState["ListicId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!long.TryParse(Request.QueryString["listicId"], out long listicId))
                {
                    // Ne postoji taj ListicId. Vraćamo se na stranicu listica.
                    Response.Redirect("~/Listici");
                }

                ListicId = listicId;

                BindPonude();
            }

            Search();
        }

        private void BindPonude()
        {
            var ponude = _ponudaRepository.GetAllPonudas();
            ponudaDropDownList.DataSource = ponude;
            ponudaDropDownList.DataBind();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            // Add new record
            var oklada = new Core.UIModel.Oklada
            {
                ListicId = ListicId,
                PonudaId = long.Parse(ponudaDropDownList.SelectedValue)
            };

            var ponuda = _ponudaRepository.GetPonuda(oklada.PonudaId);
            oklada.Koeficient = ponuda.Koeficient;

            try
            {
                var oklade = _okladaRepository.GetOkladas(ListicId);
                var okladePlusNova = oklade.Concat(new Core.UIModel.Oklada[] { oklada }).ToArray();
                var listic = _listicRepository.GetListic(ListicId);
                var moguciDobitak = _listicRepository.CalculateMoguciDobitak(ListicId, listic.IznosUplate, okladePlusNova);
                _listicRepository.ValidateMoguciDobitak(ListicId, moguciDobitak, okladePlusNova);

                _okladaRepository.Add(oklada);
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to add oklada to listić. Error: {ex.Message}");
                MessageManager.ShowMessage(this, ex.Message);
            }

            try
            {
                _okladaRepository.Save();
                _listicRepository.UpdateMoguciDobitak(ListicId);
                editPanel.Visible = false;
                Search();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Ta oklada je već dodana na ovaj listić!");
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                var listic = _listicRepository.GetListic(ListicId);
                listicLabel.Text = listic.ToString();
            }
            catch
            {
                // Ne postoji taj ListicId. Vraćamo se na stranicu listica.
                Response.Redirect("~/Listici");
            }

            var oklade = _okladaRepository.GetOkladas(ListicId);

            okladeRepeater.DataSource = oklade;
            okladeRepeater.DataBind();
        }

        protected void deleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                long okladaId = Convert.ToInt64(e.CommandArgument);
                _okladaRepository.Delete(okladaId);
                _okladaRepository.Save();

                _listicRepository.UpdateMoguciDobitak(ListicId);

                Search();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Oklada se ne može izbrisati jer već ima ponude!");
            }
        }
    }
}