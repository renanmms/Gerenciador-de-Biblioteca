using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistence.UoW;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(CreateLoanViewModel loan)
        {
            var entityLoan = loan.Adapt<Loan>();
            return _unitOfWork.Loans.Create(entityLoan);
        }

        public GetLoanViewModel GetLoanByUserIdAndBookId(int userId, int bookId)
        {
            return _unitOfWork.Loans.GetByUserIdAndBookId(userId, bookId)
                                  .Adapt<GetLoanViewModel>();
        }

        public IEnumerable<CreateLoanViewModel> GetLoansByBookId(int id)
        {
            return _unitOfWork.Loans.GetLoansByBookId(id)
                                  .Adapt<IEnumerable<CreateLoanViewModel>>();
        }

        public void Delete(int userId, int bookId)
        {
            _unitOfWork.Loans.Delete(userId, bookId);
        }
    }
}