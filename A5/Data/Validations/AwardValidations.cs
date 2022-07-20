using A5.Service;
using A5.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace A5.Data.Validations
{
    public  class AwardValidations
    {
        private readonly AppDbContext _context;
        public AwardValidations(AppDbContext context)
        {
            _context=context;
        }
        public bool RequestValidation(Award award,int employeeId)
        {
            if(award.AwardeeId==0) throw new ValidationException("Awardee not found");
            if(!award.Awardee.IsActive) throw new ValidationException("This Awardee is not active in this organisation");
            if(award.AwardTypeId==0) throw new ValidationException("Award Type Should not be null");
            if(string.IsNullOrWhiteSpace(award.Reason)) throw new ValidationException("Reason for award should not be null");
            if(!(_context.Awards!.Any(nameof=>nameof.Awardee.ReportingPersonId==employeeId))) throw new ValidationException("Reporting Person Id not found");
            else return true;
           
        }
        public static bool ValidateRequestedAward(int employeeId)
        {
            if(employeeId==0) throw new ValidationException("Id is null.Login to get the List of Requested Awards");
            else return true;
        }

        public  bool ValidateAddComment(Comment comment,int employeeId)
        {
            if(string.IsNullOrWhiteSpace(comment.Comments)) throw new ValidationException("Comments should not be null");
            if(_context.Comments.Any(nameof=>nameof.Employees.Id==employeeId)) throw new ValidationException("Login to add comments");
            else return true;
        }
        public static bool ValidateGetComments(int awardId)
        {
            if(awardId<=0) throw new ValidationException ("No such awards!!");
            else return true;
        }

        public  bool ApprovalValidation(Award award)
        {
            if(award.ApproverId==0)throw new ValidationException("Approver Id should not be zero");
            if(award.StatusId==3 && String.IsNullOrWhiteSpace(award.RejectedReason))throw new ValidationException("Rejection reason cannot be null");
            if(award.StatusId==4 && String.IsNullOrWhiteSpace(award.CouponCode))throw new ValidationException("Coupon code should not be null");
            if(award.StatusId==4 && (_context.Awards!.Any(nameof=>nameof.CouponCode==award.CouponCode)))throw new ValidationException("Coupon code already exists");
            else return true;

        }

        
    }
}