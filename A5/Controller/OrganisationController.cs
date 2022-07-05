using System;
using Microsoft.AspNetCore.Mvc;
using A5.Models;
using A5.Data.Service;
using A5.Data.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using A5.Data;
using Microsoft.AspNetCore.Authorization;

namespace A5.Controller
{
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private  ILogger<IOrganisationService> _logger;
        private  IOrganisationService _organisationService;
        public OrganisationController(ILogger<IOrganisationService> logger,  IOrganisationService organisationService)
        {
            _logger = logger;
            _organisationService = organisationService;
        } 

        /// <summary>
        ///  This Method is used to view all organisation
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET / ViewOrganisation
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <param>String</param>
        /// <returns>
        ///Return List of Organisation.
        /// </returns>

        [HttpGet("GetAll")]
        public ActionResult GetAllOrganisation()
        {
            try{
                var data = _organisationService.GetAll();
                return Ok(data);
            }
            catch(ValidationException exception)
            {
                _logger.LogError($"log: (Error: {exception.Message})");
                _logger.LogInformation($"Organisation Controller : GetAllOrganisation() : (Error:{exception.Message})");
                return BadRequest($"Error : {exception.Message}");
            }
            catch(Exception exception)
            {
                return BadRequest($"Error : {exception.Message}");
            }
            
        }
        
        /// <summary>
        ///  This Method is used to view single Organisation by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET / ViewSingleOrganisation
        ///     {
        ///        "OrganisationId" = "1",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <param name="id">String</param>
        /// <returns>
        ///Returns signle organisation by id
        /// </returns>

         [HttpGet("GetById")]
        public ActionResult GetByOrganisationId([FromQuery] int id)
        {
           if(id==0) return BadRequest("Organisation Id should not be null");
            try{
               
                var data = _organisationService.GetByOrganisation(id);
                 return Ok(data);
            }
            catch(ValidationException exception)
            {
                _logger.LogError($"log: (Error: {exception.Message})");
                _logger.LogInformation($"Organisation Controller : GetByOrganisationId(int id) : (Error : {exception.Message})");
                return BadRequest($"Error : {exception.Message}");
            }
            catch(Exception exception)
            {
                return BadRequest($"Error : {exception.Message}");
            }
            
        }
        
        /// <summary>
        ///  This Method is used to create new organisation
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / CreateOrganisation
        ///     {
        ///        "OrganisationName" = "Development",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <param name="organisation">String</param>
        /// <returns>
        ///Return "Organisation Added Successfully" when the Organisation is added in the database otherwise return "Sorry internal error occured".
        /// </returns>

        [HttpPost("Create")]
        public ActionResult Create(Organisation organisation)
        {
            if(organisation==null) return BadRequest("Organisation should not be null");
            try
            {   
                return _organisationService.CreateOrganisation(organisation) ? Ok("Organisation Created.") : Problem("Error occured while creating organisation");
                
            }
            catch(ValidationException exception)
            {
                _logger.LogError($"log: (Error: {exception.Message})");
                _logger.LogInformation($"Organisation Controller : Create(Organisation organisation) : (Error:{exception.Message}");
                return BadRequest($"Error : {exception.Message}");
            }
            catch(Exception exception)
            {
                return BadRequest($"Error : {exception.Message}");
            }
        }

        /// <summary>
        ///  This Method is used to view single Organisation by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET / ViewSingleOrganisation
        ///     {
        ///        "OrganisationId" = "1",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <param name="organisation">String</param>
        /// <returns>
        ///Returns signle organisation by id
        /// </returns>

        [HttpPut("Update")]
        public ActionResult Update(Organisation organisation)
        {
           if(organisation==null) return BadRequest("Organisation should not be null");
            try{
               
                return _organisationService.UpdateOrganisation(organisation) ?  Ok("Organisation Updated."):Problem("Error occured");          
            }        
            catch(ValidationException exception)
            {
                _logger.LogError($"log: (Error: {exception.Message})");
                _logger.LogInformation($"Organisation Controller : Update(Organisation organisation,int id) : (Error: {exception.Message})");
                return BadRequest($"Error : {exception.Message}");
            }
            catch(Exception exception)
            {
                return BadRequest($"Error : {exception.Message}");
            }
        }

        /// <summary>
        ///  This Method is used to disable the organisation by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT / DisableOrganisation
        ///     {
        ///        "OrganisationId" = "1",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <param name="id">String</param>
        /// <returns>
        ///Return "Organisation Disabled Successfully" message when the isactive filed is set to 0 otherwise return "Sorry internal error occured".
        /// </returns>

        [HttpPut("Disable")]
        public ActionResult Disable(int id)
        {
            
            try
            {
                var checkEmployee=_organisationService.GetCount(id);
                if(checkEmployee > 0)
                {             
                    return Ok(checkEmployee);
                    // return Ok ( new{Message= "There are certain Employees in that Organisation. You're gonna change their Organisation to disable this Organisation." } );
                }
                else
                {
                    var data = _organisationService.DisableOrganisation(id);
                    return Ok(data);
                }
            }
            catch(ValidationException exception)
            {
                _logger.LogError($"log: (Error: {exception.Message})");
                _logger.LogInformation($"Organisation Controller : Disable(int id) : (Error : {exception.Message})");
                return BadRequest($"Error : {exception.Message}");
            }
            catch(Exception exception)
            {
                return BadRequest($"Error : {exception.Message}");
            }
        }
    }
}