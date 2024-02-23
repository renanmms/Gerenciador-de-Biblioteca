using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public int Create(CreateBookViewModel book)
        {
            var entityBook = book.Adapt<Book>();
            return _bookRepository.Create(entityBook);
        }

        public int Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public IEnumerable<GetBookViewModel> GetAll(string query)
        {
            return _bookRepository.GetAll(query)
                                  .Adapt<IEnumerable<GetBookViewModel>>();
        }

        public GetBookViewModel GetById(int id)
        {
            return _bookRepository.GetById(id)
                                  .Adapt<GetBookViewModel>();
        }
    }
}