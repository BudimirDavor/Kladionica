using Kladionica.Core;
using log4net;
using System;
using System.Web.UI.WebControls;

namespace Kladionica
{
    public partial class Listici : System.Web.UI.Page
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Listici));
        private readonly IListicRepository _listicRepository;

        public Listici()
        {
            _listicRepository = ListicRepositoryFactory.Create();
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
            if (!IsValid)
            {
                return;
            }

            if (IsEditMode)
            {
                var listic = new Core.UIModel.Listic
                {
                    ListicId = long.Parse(vrijemeUplateTextBox.ToolTip),
                    VrijemeUplate = DateTime.Parse(vrijemeUplateTextBox.Text),
                    IznosUplate = double.Parse(iznosUplateTextBox.Text),
                    UpdateDate = DateTime.Parse(iznosUplateTextBox.ToolTip)
                };

                try
                {
                    var okladaRepository = OkladaRepositoryFactory.Create();
                    var oklade = okladaRepository.GetOkladas(listic.ListicId);
                    var moguciDobitak = _listicRepository.CalculateMoguciDobitak(listic.ListicId, listic.IznosUplate, oklade);
                    _listicRepository.ValidateMoguciDobitak(listic.ListicId, moguciDobitak, oklade);

                    _listicRepository.Update(listic);
                    _listicRepository.UpdateMoguciDobitak(listic.ListicId);
                    _logger.Info("Succesfully updated listić and mogući dobitak.");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to update listić and/or mogući dobitak. Error: {ex.Message}");
                    MessageManager.ShowMessage(this, ex.Message);
                }
            }
            else
            {
                // Add new record
                var listic = new Core.UIModel.Listic
                {
                    VrijemeUplate = DateTime.Parse(vrijemeUplateTextBox.Text),
                    IznosUplate = double.Parse(iznosUplateTextBox.Text)
                };

                try
                {
                    _listicRepository.Add(listic);
                    _listicRepository.Save();
                    _logger.Info($"Successfully added new listić to database. Listić: {listic}");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to add new listic to database: Error: {ex.Message}");
                }
            }

            ClearTextBoxes();
            ClearSearchBoxes();
            editPanel.Visible = false;

            Search();
        }

        private void ClearTextBoxes()
        {
            vrijemeUplateTextBox.Text = string.Empty;
            iznosUplateTextBox.Text = string.Empty;
            IsEditMode = false;
        }

        private void ClearSearchBoxes()
        {
            vrijemeUplateSearchTextBox.Text = string.Empty;
            iznosUplateSearchTextBox.Text = string.Empty;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var listici = _listicRepository.GetListics(vrijemeUplateSearchTextBox.Text.Trim(), iznosUplateSearchTextBox.Text.Trim());

            listiciRepeater.DataSource = listici;
            listiciRepeater.DataBind();
        }

        protected void editLinkButton_Command(object sender, CommandEventArgs e)
        {
            long listicId = Convert.ToInt64(e.CommandArgument);
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

                // Put ListicId in the ToolTip of the text box 
                // so it can be used to find record before updating it.
                vrijemeUplateTextBox.ToolTip = listicId.ToString();

                var listic = _listicRepository.GetListic(listicId);
                vrijemeUplateTextBox.Text = listic.VrijemeUplate.ToString();
                iznosUplateTextBox.Text = listic.IznosUplate.ToString();
                iznosUplateTextBox.ToolTip = listic.UpdateDate.ToString();
            }
            else if (e.CommandName == "link")
            {
                Response.Redirect($"~/Oklade.aspx?listicId={listicId}");
            }
        }

        protected void deleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                long listicId = Convert.ToInt64(e.CommandArgument);
                _listicRepository.Delete(listicId);
                _listicRepository.Save();
                IsEditMode = false;
                Search();
            }
            catch
            {
                MessageManager.ShowMessage(this, "Listic se ne može izbrisati jer već ima oklade!");
            }
        }

        protected void vrijemeUplateRan_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DateTime.TryParse(vrijemeUplateTextBox.Text.Trim(), out DateTime vrijeme);
        }
    }
}