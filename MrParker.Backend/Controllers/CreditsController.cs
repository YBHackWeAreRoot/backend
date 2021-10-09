using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker.Controllers
{
    [ApiController]
    public class CreditsController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/raw")]
        public string GetCreditsString()
        {
            return @"
bla
bla
";
        }

        [HttpGet]
        [Route("[controller]")]
        public ContentResult GetCreditsHtml()
        {
            var template = $@"<!doctype html>
<html lang=""en"">
<head>
    <meta charset=""utf-8"">
    <title>WeAreRoot - Credits | Hackathon 2021</title>
</head>
<body>
    <pre>
{GetCreditsString()}
    </pre>
</body>
</html>";

            return base.Content(template, "text/html; charset=utf-8");
        }
    }
}
