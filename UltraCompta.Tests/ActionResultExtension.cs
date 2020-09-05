using Microsoft.AspNetCore.Mvc;

namespace UltraCompta.Tests
{
    public static class ActionResultExtension
    {
        public static string Response(this IActionResult actionResult)
        {
            var contentResult = actionResult as ContentResult;
            return contentResult?.Content;
        }
    }
}