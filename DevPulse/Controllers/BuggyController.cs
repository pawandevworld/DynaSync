using DevPulse.Controllers;
using DevPulse.Data;
using DevPulse.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devpulse;

public class BuggyController(DataContext context) : BaseDevPulseController
{
    [Authorize]
    [HttpGet("auth")]

    public ActionResult<string> GetAuth()
    {
        return "You are authorized";        
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = context.Users.Find(-1);
        if (thing == null) return NotFound();
        return thing; 
    }

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing has happened");
        return thing;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()//Error from 400 to 499
    {
        return BadRequest("This was not a good request");
    }    
}