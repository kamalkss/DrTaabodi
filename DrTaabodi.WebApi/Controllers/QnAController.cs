using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.QnATable;
using DrTaabodi.WebApi.DTO.QnAs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers
{
    [Route("/api/qna/")]
    [ApiController]
    public class QnAController:ControllerBase
    {
        private readonly DrTaabodiDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<QnAController> _logger;
        private readonly IQnA _qnA;

        public QnAController(ILogger<QnAController> logger,DrTaabodiDbContext db,IMapper mapper,IQnA qna)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _qnA = qna;
        }

        [HttpGet]
        public async Task<ActionResult<ReadQnAs>> GetAllQna([FromHeader] QnAParametes qnaParameters)
        {
            _logger.LogInformation("Get all QnAs");
            var Qna = await _qnA.GetAllQnATbls(qnaParameters);
            return Ok(Qna);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadQnAs>> GetQnaById(Guid id)
        {
            _logger.LogInformation("Get Id Qna");
            var qna = await _qnA.GetQnATblById(id);
            return Ok(_mapper.Map<QnATbl>(qna));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CreateQnAs>>> CreateQna([FromBody] CreateQnAs CreateQna)
        {
            _logger.LogInformation("Create a qna");
            
            var mapQna = _mapper.Map<QnATbl>(CreateQna);
            var newQna = await _qnA.CreateQnATbl(mapQna);
            return Ok(newQna);
        }

        [HttpPatch]
        public async Task<ActionResult<ServiceResponse<ReadQnAs>>> UpdateQna([FromBody] ReadQnAs UpdateQna)
        {
            _logger.LogInformation("Update Qna");
            var id = UpdateQna.QnAId;
            var Qna = _mapper.Map<QnATbl>(UpdateQna);
            var updatedQna = await _qnA.UpdateQnATblQuestion(id, Qna);
            return Ok(updatedQna);
        }


       

    }
    public record UrlQueryParameters(int Limit = 50, int Page = 1);
}
