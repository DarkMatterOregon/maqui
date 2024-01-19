using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using DarkMatter.Module.Maqui.Repository;
using Oqtane.Controllers;
using System.Net;

namespace DarkMatter.Module.Maqui.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class MaquiController : ModuleControllerBase
    {
        private readonly IMaquiRepository _MaquiRepository;

        public MaquiController(IMaquiRepository MaquiRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _MaquiRepository = MaquiRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Maqui> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _MaquiRepository.GetMaquis(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Maqui Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Maqui Get(int id)
        {
            Models.Maqui Maqui = _MaquiRepository.GetMaqui(id);
            if (Maqui != null && IsAuthorizedEntityId(EntityNames.Module, Maqui.ModuleId))
            {
                return Maqui;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Maqui Get Attempt {MaquiId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Maqui Post([FromBody] Models.Maqui Maqui)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, Maqui.ModuleId))
            {
                Maqui = _MaquiRepository.AddMaqui(Maqui);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Maqui Added {Maqui}", Maqui);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Maqui Post Attempt {Maqui}", Maqui);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Maqui = null;
            }
            return Maqui;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Maqui Put(int id, [FromBody] Models.Maqui Maqui)
        {
            if (ModelState.IsValid && Maqui.MaquiId == id && IsAuthorizedEntityId(EntityNames.Module, Maqui.ModuleId) && _MaquiRepository.GetMaqui(Maqui.MaquiId, false) != null)
            {
                Maqui = _MaquiRepository.UpdateMaqui(Maqui);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Maqui Updated {Maqui}", Maqui);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Maqui Put Attempt {Maqui}", Maqui);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Maqui = null;
            }
            return Maqui;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Maqui Maqui = _MaquiRepository.GetMaqui(id);
            if (Maqui != null && IsAuthorizedEntityId(EntityNames.Module, Maqui.ModuleId))
            {
                _MaquiRepository.DeleteMaqui(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Maqui Deleted {MaquiId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Maqui Delete Attempt {MaquiId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
