using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistence.UoW;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(CreateBookViewModel book)
        {
            var entityBook = book.Adapt<Book>();
            return _unitOfWork.Books.Create(entityBook);
        }

        public int Delete(int id)
        {
            return _unitOfWork.Books.Delete(id);
        }

        public IEnumerable<GetBookViewModel> GetAll(string query)
        {
            return _unitOfWork.Books.GetAll(query)
                                  .Adapt<IEnumerable<GetBookViewModel>>();
        }

        public GetBookViewModel GetById(int id)
        {
            return _unitOfWork.Books.GetById(id)
                                  .Adapt<GetBookViewModel>();
        }
    }
}