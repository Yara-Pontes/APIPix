using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIPix.Pages
{
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            RequestId = HttpContext.TraceIdentifier; // Captura o ID da solicitação
        }
    }
}
