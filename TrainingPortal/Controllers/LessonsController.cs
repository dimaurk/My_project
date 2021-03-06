﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using DataAccessLayer.Models;
using DataAccessLayer.ConnectionSettings;
using DataAccessLayer.Repository;
using DataAccessLayer.Utilities;
using DataAccessLayer.Translators;

namespace TrainingPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/lessons")]
    public class LessonsController : Controller
    {
        private readonly IOptions<ConnectSettingsModel> appSettings;

        public LessonsController(IOptions<ConnectSettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        public IActionResult GetLessons()
        {

            var data = DbClientFactory<LessonsDbClient>.Instance.GetAllLessons(appSettings.Value.ConnectionString);

            return Ok(data);
        }
    }
}