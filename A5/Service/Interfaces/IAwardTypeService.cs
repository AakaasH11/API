using System.Collections.Generic;
using System.Linq;
using A5.Models;
namespace A5.Service.Interfaces
{
    public interface IAwardTypeService 
    {
        public bool CreateAwardType(AwardType entity);
        public bool DisableAwardType(int id);
        public bool UpdateAwardType(AwardType entity);
        public AwardType? GetAwardTypeById(int id);
        public IEnumerable<AwardType> GetAllAwardType();
        public object ErrorMessage(string ValidationMessage);
    
    
    }
}