using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizManage.Pages.Admin.UserPages
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
