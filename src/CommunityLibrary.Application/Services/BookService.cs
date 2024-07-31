/// <summary>
/// Implements the IBookService interface to provide business logic for Book-related operations.
/// This service acts as an intermediary between the API controllers and the repository,
/// encapsulating the application's business rules for managing books.
/// </summary>

using AutoMapper;
using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> AddBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var addedBook = await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(addedBook);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                await _bookRepository.DeleteAsync(book);
            }
        }
    }
}