using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEventsAdoNetDB.Entities;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;

namespace MyEventsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IEFUnitOfWork _EFuow;
        private IUnitOfWork _ADOuow;
        public UserController(ILogger<UserController> logger,
            IEFUnitOfWork unitOfWork,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _EFuow = unitOfWork;
            _ADOuow = ado_unitofwork;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllUsersAsync()
        {
            try
            {
                var results = await _ADOuow._userProfileRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всіх користувачів з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }

        }
    }
}
