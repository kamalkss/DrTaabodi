using System;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
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
        public ActionResult<ReadQnAs> GetAllQna()
        {
            _logger.LogInformation("Get all QnAs");
            var Qna = _qnA.GetAllQnATbls();
            return Ok(Qna);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadQnAs> GetQnaById(Guid id)
        {
            _logger.LogInformation("Get Id Qna");
            var qna = _qnA.GetQnATblById(id);
            return Ok(_mapper.Map<QnATbl>(qna));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<CreateQnAs>> CreateQna([FromBody] CreateQnAs CreateQna)
        {
            _logger.LogInformation("Create a qna");
            
            var mapQna = _mapper.Map<QnATbl>(CreateQna);
            var newQna = _qnA.CreateQnATbl(mapQna);
            return Ok(newQna);
        }

        [HttpPatch]
        public ActionResult<ServiceResponse<ReadQnAs>> UpdateQna([FromBody] ReadQnAs UpdateQna)
        {
            _logger.LogInformation("Update Qna");
            var id = UpdateQna.QnAId;
            var question = UpdateQna.Question;
            var answer = UpdateQna.Answer;
            var updatedQna = _qnA.UpdateQnATblAnswerOrAnswer(id, answer, question);
            return Ok(_mapper.Map<QnATbl>(updatedQna));
        }
    }
}
