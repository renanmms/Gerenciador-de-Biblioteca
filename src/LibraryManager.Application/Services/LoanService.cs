using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public int Create(CreateLoanViewModel loan)
        {
            var entityLoan = loan.Adapt<Loan>();
            return _loanRepository.Create(entityLoan);
        }

        public GetLoanViewModel GetLoanByUserIdAndBookId(int userId, int bookId)
        {
            return _loanRepository.GetByUserIdAndBookId(userId, bookId)
                                  .Adapt<GetLoanViewModel>();
        }

        public IEnumerable<CreateLoanViewModel> GetLoansByBookId(int id)
        {
            return _loanRepository.GetLoansByBookId(id)
                                  .Adapt<IEnumerable<CreateLoanViewModel>>();
        }

        public void Delete(int userId, int bookId)
        {
            _loanRepository.Delete(userId, bookId);
        }
    }
}