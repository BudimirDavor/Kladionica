using Kladionica.Core;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Kladionica
{
    public partial class Ponude : System.Web.UI.Page
    {
        private readonly ISusretRepository _susretRepository;
        private readonly IPonudaRepository _ponudaRepository;

        public Ponude()
        {
            _susretRepository = SusretRepositoryFactory.Create();
            _ponudaRepository = PonudaRepositoryFactory.Create();
        }

        // To know whether we are adding a new record
        // or editing one selected from the grid.
        private bool IsEditMode
        {
            get { return Convert.ToBoolean(ViewState["IsEdit"]); }
            set { ViewState["IsEdit"] = value; }
        }

        private long SusretId
        {
            get { return Convert.ToInt64(ViewState["SusretId"]); }
            set { ViewState["SusretId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsEditMode = false;

                if (!long.TryParse(Request.QueryString["susretId"], out long susretId))
                {
                    // Ne postoji taj SusretId. Vraćamo se na stranicu susreta.
                    Response.Redirect("~/Susreti");
                }
                 
                SusretId = susretId;

                try
                {
                    var susret = _susretRepository.GetSusret(susretId);
                    susretLabel.Text = susret.ToString();
                }
                catch
                {
                    // Ne postoji taj SusretId. Vraćamo se na stranicu susreta.
                    Response.Redirect("~/Susreti");
                }
            }

            Search();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
            IsEditMode = false;
        }

        protected void saveLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                var ponuda = new Core.UIModel.Ponuda
                {
                    PonudaId = long.Parse(koeficientTextBox.ToolTip),
                    SusretId = SusretId,
                    Tip = tipDropDownList.SelectedValue,
                    Koeficient = double.Parse(koeficientTextBox.Text)
                };

                _ponudaRepository.Update(ponuda);
            }
            else
            {
                // Add new record
                var ponuda = new Core.UIModel.Ponuda
                {
                    SusretId = SusretId,
                    Tip = tipDropDownList.SelectedValue,
                    Koeficient = double.Parse(koeficientTextBox.Text)
                };

                _ponudaRepository.Add(ponuda);
            }

            try
            {
                _ponudaRepository.Save();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Takva ponuda već postoji za taj susret!");
            }

            ClearTextBoxes();
            editPanel.Visible = false;

            Search();
        }

        private void ClearTextBoxes()
        {
            koeficientTextBox.Text = string.Empty;
            IsEditMode = false;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var ponude = _ponudaRepository.GetPonudas(SusretId);

            ponudeRepeater.DataSource = ponude;
            ponudeRepeater.DataBind();
        }

        protected void editLinkButton_Command(object sender, CommandEventArgs e)
        {
            long ponudaId = Convert.ToInt64(e.CommandArgument);
            var linkButton = sender as LinkButton;

            // We want to hide clicked icon in the grid
            // to know which record (row in the grid) is being edited.
            if (linkButton != null)
            {
                linkButton.Visible = false;
            }

            if (e.CommandName == "edit")
            {
                editPanel.Visible = true;
                IsEditMode = true;

                // Put PonudaId in the ToolTip of the text box 
                // so it can be used to find record before updating it.
                koeficientTextBox.ToolTip = ponudaId.ToString();

                var ponuda = _ponudaRepository.GetPonuda(ponudaId);
                tipDropDownList.SelectedValue = ponuda.Tip;
                koeficientTextBox.Text = ponuda.Koeficient.ToString();
            }
        }

        protected void deleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                long ponudaId = Convert.ToInt64(e.CommandArgument);
                _ponudaRepository.Delete(ponudaId);
                _ponudaRepository.Save();
                IsEditMode = false;
                Search();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Ponuda se ne može izbrisati jer već ima oklade!");
            }
        }
    }
}
