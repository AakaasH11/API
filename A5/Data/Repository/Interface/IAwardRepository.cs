using A5.Models;
using A5.Data;

namespace A5.Data.Repository.Interface
{
    public interface IAwardRepository
    {
        bool RaiseAwardRequest(Award award);
        bool ApproveRequest(Award award);
        Award? GetAwardById(int awardId);
        bool AddComments(Comment comment);
        IEnumerable<Comment> GetComments(int awardId);
        IEnumerable<Award> GetAllAwardsList(int? pageId, int? employeeId);

    }
}