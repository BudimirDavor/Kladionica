using System.Web.UI;

namespace Kladionica.Core
{
    public static class MessageManager
    {
        public static void ShowMessage(Page page, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "js", $"alert('{message}');", true);
        }
    }
}