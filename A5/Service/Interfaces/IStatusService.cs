using A5.Models;
using A5.Data;
namespace A5.Service.Interfaces
{
    public interface IStatusService
    {
        Status? GetStatusById(int statusId);
        IEnumerable<Status> GetAllStatus();

    }


}