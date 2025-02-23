using AutoMapper;
using DevPulse.Data;
using DevPulse.DTOs;
using DevPulse.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevPulse.Controllers;

//[ApiController]
//[Route("devpulse/[controller]")] //localhost/devpusle/users the users (replaced by first part of namespace that is UsersController)
//Initially we created these here but nuw since we created a BaseDevPulseController this code will be moved there and ControllerBase will be replaced by it

//public class UsersController(DataContext context) : ControllerBase
//public class UsersController(DataContext context) : BaseDevPulseController
//since we have setup the IuserRepository and UserRepository we can use the interface instead of the DataContext

//Also now [AllowAnonymous] and [Authorize] are not needed each method and simply use [Authorize] on the class
//Also we can use the IUserRepository instead of the DataContext
//Also we can use the BaseDevPulseController instead of the ControllerBase
[Authorize] //This will make sure that all the methods in the controller are authorized
public class UsersController(IUserRepository userRepository) : BaseDevPulseController
{

    //[AllowAnonymous]
    //We can only have one HttpGet method in the controller
    [HttpGet]//1st API end point get request

    //2nd end point methods to return http response to the client
    //Once multiple users are using the ActionResult we need to make
    //sure that all the action is Asynchronous and for that so the 
    //line public ActionResult<IEnumerable<AppUser>> GetUsers() will be
    //public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
    //and use the keyword await to get the data from the database
    //and the method ToLiatAsync() to get the data from the database
    //this will require the using Microsoft.EntityFrameworkCore;
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        //return http response to the client here
        //in our case it will be list of users
        //now we will change the context to userRepository var users = await context.Users.ToListAsync();
        var users = await userRepository.GetMembersAsync();
        //not needed anymore since not using memberdto var usersToReturn = mapper.Map<IEnumerable<DTOs.MemberDto>>(users);
        //Now we can sipmly return the users
        //or return ok(users) to return 200 status code
        //or return NotFound() to return 404 status code
        //or return BadRequest() to return 400 status code
        return Ok(users);
    }


    //[Authorize]
    //Since We can only have one HttpGet method in the controller
    //We can use the HttpGet method to get a single user by passing parameter
    //This way we can sreat multiple requests to the same endpoint
    //switch to username [HttpGet("{id:int}")]//devpusle/users/2
    [HttpGet("{username}")]//devpusle/users/2
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        //change this line var user = await context.Users.FindAsync(id);
        //to 
        var user = await userRepository.GetMemberAsync(username);
        if(user == null) return NotFound();
        
        return user;
    }
}

//This is the initial code for the UsersController
//but this can be set up in a different way by clicking 
//on the constructor and quic fix to "Use Primary Constructor"
//and then we dont need the private field _context
/*public class UsersController : ControllerBase
{
    //use _for private fields
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]//1st API end point get request

    //2nd end point methods to return http response to the client
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
            //return http response to the client here
    }
}*/