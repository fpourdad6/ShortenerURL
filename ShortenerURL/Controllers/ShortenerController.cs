using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using ShortenerURL.Models;

namespace ShortenerURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenerController : ControllerBase
    {
        private readonly IShortenerUrl _shortenerUrlRepository;

        public ShortenerController(IShortenerUrl shortenerUrlRepository)
        {
            this._shortenerUrlRepository = shortenerUrlRepository;
        }
        [HttpPost]
        public ActionResult<BaseResponse<string>> Post(BaseRequest<string> request)
        {
            if (!Uri.TryCreate(request.Body, UriKind.Absolute, out var inputUri))
            {
                return BadRequest();
            }
         
            var e = _shortenerUrlRepository.Add(inputUri.ToString());
            var result = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{e.UrlKey}";
            return Ok(new BaseResponse<string> { Result = result });
        }
        [Route("/{id}")]
        [HttpGet]

        public ActionResult<BaseResponse<string>> Get(string id)
        {
            var res = _shortenerUrlRepository.Get(id);
            if (res != null)
            {
                return new RedirectResult(res?.LongUrl ?? "/");
            }
            return BadRequest(new { description = "invalid url" });
        }
    }
}
