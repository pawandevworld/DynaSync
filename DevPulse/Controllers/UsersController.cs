using DevPulse.Data;
using DevPulse.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevPulse;

[ApiController]
[Route("devpulse/[controller]")] //localhost/devpusle/users the users (replaced by first part of namespace that is UsersController)

public class UsersController(DataContext context) : ControllerBase
{
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
        var users = await context.Users.ToListAsync();

        //Now we can sipmly return the users
        //or return ok(users) to return 200 status code
        //or return NotFound() to return 404 status code
        //or return BadRequest() to return 400 status code
        return users;
    }


    //Since We can only have one HttpGet method in the controller
    //We can use the HttpGet method to get a single user by passing parameter
    //This way we can sreat multiple requests to the same endpoint
    [HttpGet("{id:int}")]//devpusle/users/2
    
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);
        
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