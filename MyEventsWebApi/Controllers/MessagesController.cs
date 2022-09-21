using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsEntityFrameworkDb.Entities;
using MyEventsEntityFrameworkDb.Entities.Pagination;
using MyEventsWebApi.Extensions;

namespace MyEventsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private IEFUnitOfWork _EFuow;
        private IUnitOfWork _ADOuow;
        public MessagesController(ILogger<MessagesController> logger,
            IEFUnitOfWork unitOfWork,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _EFuow = unitOfWork;
            _ADOuow = ado_unitofwork;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Message>>> GetPaginatedMessagesAsync([FromQuery] ShowMessageParameters showMessageParameters)
        {
            try
            {
                var results = await _EFuow.EFMessageRepository.GetPaginatedMessagesAsync(showMessageParameters);
                Response.Headers.Add("X-Pagination", results.SerializeMetadata());

                _logger.LogInformation($"Отримали пропагіновані елементи з БД");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Запит не відпрацював, щось пішло не так! - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
