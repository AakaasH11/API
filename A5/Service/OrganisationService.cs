using A5.Models;
using A5.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using A5.Service.Validations;
using A5.Data.Repository.Interface;

namespace A5.Service
{
    public class OrganisationService :  IOrganisationService
    {
        private readonly IOrganisationRepository _organisationRepository;
       private readonly ILogger<OrganisationService> _logger;

        public OrganisationService(ILogger<OrganisationService> logger,IOrganisationRepository organisationRepository)  {
                _logger=logger;
                _organisationRepository=organisationRepository;
         } 
         
         //Create an Oraganisation using organisation object
        public bool CreateOrganisation(Organisation organisation)
        {
            OrganisationServiceValidations.CreateValidation(organisation);
            try{
                return _organisationRepository.CreateOrganisation(organisation);
            }
            catch(ValidationException exception)
            {
                _logger.LogError("OrganisationService: CreateOrganisation(Organisation organisation) : (Error:{Message}",exception.Message);
                throw;
            }
            catch(Exception exception)
            {
                 _logger.LogError("OrganisationService: CreateOrganisation(Organisation organisation) : (Error:{Message}",exception.Message);
                throw;
            }
        }

        //Updating the Organisation using organisation object
        public bool UpdateOrganisation(Organisation organisation)
        {
            OrganisationServiceValidations.UpdateValidation(organisation);
            try{
                return _organisationRepository.UpdateOrganisation(organisation);
            }
            catch(ValidationException exception)
            {
                _logger.LogError("OrganisationService: UpdateOrganisation(Organisation organisation) : (Error:{Message}",exception.Message);
                throw;
            }
            catch(Exception exception)
            {
                 _logger.LogError("OrganisationService: UpdateOrganisation(Organisation organisation) : (Error:{Message}",exception.Message);
                throw;
            }
        }

        //Gets organisation by using organisation id
        public Organisation? GetOrganisationById(int organisationId)
        {
            if(organisationId<=0) throw new ValidationException("organisationId must be greater than zero");
            try{
                return _organisationRepository.GetOrganisationById(organisationId);
            }
            catch(Exception exception)
            {
               _logger.LogError("OrganisationService: GetByOrganisation(int organisationId) : (Error:{Message}",exception.Message);
                throw;
            }
        }
         
         //returns list of all organisation
         public IEnumerable<Organisation> GetAllOrganisation()
        {
            
            try{
                return _organisationRepository.GetAllOrganisation();
            }
            catch(Exception exception)
            {
                 _logger.LogError("OrganisationService: GetAllOrganisation() : (Error:{Message}",exception.Message);
                throw;
            }
        }
        
        //disables organisation using organisation id and current user id
        public bool DisableOrganisation(int organisationId,int employeeId)
        {            
            try
            {
                return _organisationRepository.DisableOrganisation(organisationId,employeeId);

            }
            catch(Exception exception)
            {
                _logger.LogError("OrganisationService: DisableOrganisation(int organisationId) : (Error:{Message}",exception.Message);
                throw;
            }
        }
        
        //Gets count of organisation using organisation id
        public int GetCount(int organisationId)
        {
             return _organisationRepository.GetCount(organisationId);
        }
        public object ErrorMessage(string ValidationMessage)
        {
            return new{message=ValidationMessage};
        }
       
    }

   
}



