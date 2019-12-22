using Kladionica.Core;
using System;
using System.Web.UI.WebControls;

namespace Kladionica
{
    public partial class Susreti : System.Web.UI.Page
    {
        private readonly ISusretRepository _susretRepository;

        public Susreti()
        {
            _susretRepository = SusretRepositoryFactory.Create();
        }

        // To know whether we are adding a new record
        // or editing one selected from the grid.
        private bool IsEditMode
        {
            get { return Convert.ToBoolean(ViewState["IsEdit"]); }
            set { ViewState["IsEdit"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsEditMode = false;
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
                var susret = new Core.UIModel.Susret
                {
                    SusretId = long.Parse(domacinTextBox.ToolTip),
                    Domacin = domacinTextBox.Text,
                    Gost = gostTextBox.Text
                };

                _susretRepository.Update(susret);
            }
            else
            {
                // Add new record
                var susret = new Core.UIModel.Susret
                {
                    Domacin = domacinTextBox.Text,
                    Gost = gostTextBox.Text
                };

                _susretRepository.Add(susret);
            }

            _susretRepository.Save();

            ClearTextBoxes();
            ClearSearchBoxes();
            editPanel.Visible = false;

            Search();
        }

        private void ClearTextBoxes()
        {
            domacinTextBox.Text = string.Empty;
            gostTextBox.Text = string.Empty;
            IsEditMode = false;
        }

        private void ClearSearchBoxes()
        {
            domacinSearchTextBox.Text = string.Empty;
            gostSearchTextBox.Text = string.Empty;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var susreti = _susretRepository.GetSusrets(domacinSearchTextBox.Text.Trim(), gostSearchTextBox.Text.Trim());

            susretiRepeater.DataSource = susreti;
            susretiRepeater.DataBind();
        }

        protected void editLinkButton_Command(object sender, CommandEventArgs e)
        {
            long susretId = Convert.ToInt64(e.CommandArgument);
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

                // Put SusretId in the ToolTip of the text box 
                // so it can be used to find record before updating it.
                domacinTextBox.ToolTip = susretId.ToString();
                    
                var susret = _susretRepository.GetSusret(susretId);
                domacinTextBox.Text = susret.Domacin;
                gostTextBox.Text = susret.Gost;
            }   
            else if (e.CommandName == "link")
            {
                Response.Redirect($"~/Ponude.aspx?susretId={susretId}");
            }
        }

        protected void deleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                long susretId = Convert.ToInt64(e.CommandArgument);
                _susretRepository.Delete(susretId);
                _susretRepository.Save();
                IsEditMode = false;
                Search();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Susret se ne može izbrisati jer već ima ponude!");
            }
        }
    }
}