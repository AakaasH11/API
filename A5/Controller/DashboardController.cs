using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using A5.Data;
using A5.Data.Repository;
using A5.Service;
using A5.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A5.Controller
{

    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardService _dashboardService;
        private readonly ILogger<IDashboardService> _logger;

        public DashboardController(ILogger<IDashboardService> logger, IDashboardService dashboard)
        {
            _dashboardService = dashboard;
            _logger = logger;
        }


        //Get Method - To Retrieve All Awardees.

        [HttpGet("GetAllAwardsLast1Year")]
        [AllowAnonymous]
        public ActionResult GetAllAwardsLast1Year()
        {
            try
            {
                var data = _dashboardService.GetAllAwardsLast1Year();
                return Ok(data);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetDashboardDetailsByFilters")]
        [AllowAnonymous]
        public ActionResult GetDashboardDetailsByFilters(int organisationId, int departmentId, int awardId, DateTime start, DateTime end)
        {

            try
            {
                var data = _dashboardService.GetDashboardDetailsByFilters(organisationId, departmentId, awardId, start, end);
                return Ok(data);
            }
            catch (ValidationException exception)
            {
                _logger.LogError("AwardController : GetComments(int id) : (Error:{Message}", exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError("AwardController : GetComments(int id) : (Error:{Message}", exception.Message);
                return Problem(exception.Message);
            }

        }


    }
}