using IS_API.Contracts.BLL;
using IS_API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentBLL _documentBLL;
        private readonly IUserProfileBLL _userProfileBLL;

        public DocumentsController(IDocumentBLL documentBLL, IUserProfileBLL userProfileBLL)
        {
            _documentBLL = documentBLL;
            _userProfileBLL = userProfileBLL;
        }

        [HttpPost]
        [Route("InsertDocument")]
        public IActionResult InsertDocument(Document document)
        {
            try
            {
                var userDetails = _userProfileBLL.GetUserById(document.Fk_UserId);
                if (userDetails == null)
                {
                    return NotFound("User Not Found");
                }
                _documentBLL.InsertDocument(document);
                return Ok("Document Successfullt Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserDocument")]
        public IActionResult GetUserDocument(int userId)
        {
            try
            {
                var results = _documentBLL.GetDocument(userId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllDocuments()
        {
            try
            {
                var results = _documentBLL.GetAllDocuments();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UploadDocument")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Documents");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
