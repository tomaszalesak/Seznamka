using System.Security.Claims;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IChatFacade _chatFacade;

    public ChatController(IHttpContextAccessor httpContextAccessor, IChatFacade chatFacade)
    {
        _httpContextAccessor = httpContextAccessor;
        _chatFacade = chatFacade;
    }
    
    [HttpGet("mychats")]
    public ActionResult<IList<ChatUserNameDto>> GetMyChats()
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        var chats = _chatFacade.GetMyChats(jwtUsername);
        return Ok(chats);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<MessageDto>>> GetChatMessages([FromQuery] int chatId)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var mesages = await _chatFacade.GetChatByIdAsync(chatId);
        return Ok(mesages);
    }
}