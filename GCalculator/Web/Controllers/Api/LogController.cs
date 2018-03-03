using System;
using System.Web.Http;
using Logger;
using Logger.Interfaces;
using Services;
using Services.Interfaces;
using Web.Models;

namespace Web.Controllers.Api
{
    public class LogController : ApiController
    {

        private readonly ILogReader _logReader;
        private readonly ILogger _logger = LoggerContext.Instance;

        public LogController(ILogReader logReader)
        {
            _logReader = logReader;
        }

        [Route("api/log/logwarning")]
        [HttpPut]
        public IHttpActionResult LogWarning([FromBody]MessageGrb message)
        {
            _logger.Warn(message.Message);
            return Ok("warning logged");
        }

        [Route("api/log/loginfo")]
        [HttpPut]
        public IHttpActionResult LogInfo([FromBody]MessageGrb message)
        {
            _logger.Info(message.Message);
            return Ok("info logged");
        }

        [Route("api/log/logerror")]
        [HttpPut]
        public IHttpActionResult LogError([FromBody]MessageGrb message)
        {
            _logger.Error(message.Message);
            return Ok("error logged");
        }

        [Route("api/log/logfatal")]
        [HttpPut]
        public IHttpActionResult LogFatal([FromBody]MessageGrb message)
        {
            _logger.Fatal(message.Message);
            return Ok("fatal logged");
        }

        [Route("api/log/getloglist")]
        [HttpGet]
        public IHttpActionResult GetLogList()
        {
            var loglist = _logReader.LogList();
            return Ok(loglist);
        }

        [Route("api/log/getlogdetails")]
        [HttpGet]
        public IHttpActionResult GetLogDetails([FromUri]string logName)
        {
            var deList = _logReader.ReadLog(logName);
            return Ok(deList);
        }
    }
}
