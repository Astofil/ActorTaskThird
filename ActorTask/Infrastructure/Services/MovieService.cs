using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Filters;
using AutoMapper;


namespace Infrastructure.Services;

public class MovieService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public MovieService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<List<GetMovieDto>>> GetMoviesByName(MovieFilter movieName)
    { 
        var find = await _context.Movies.ToListAsync();
        var list = new List<GetMovieDto>();

        movieName = new MovieFilter(movieName.Name, movieName.PageNumber, movieName.PageSize);
        
        var query = _context.Movies.AsQueryable();
            if(movieName.Name != null) query = query.Where(x => x.Title.Contains(movieName.Name));
            
            var filtered = await query.Skip((movieName.PageNumber - 1)* movieName.PageSize)
            .Take(movieName.PageSize).ToListAsync();

            var mapped = _mapper.Map<List<GetMovieDto>>(filtered);
        var totalRecords = await _context.Movies.CountAsync();

        foreach(var f in find)
        {
            var movie = new GetMovieDto()
            {
                MovieId = f.MovieId,
                Title = f.Title,
                MovieYear = f.MovieYear
            };
            list.Add(movie);
        }

        return new PaginationResponse<List<GetMovieDto>>(mapped, totalRecords, movieName.PageSize, movieName.PageNumber);
    }

    public async Task<Response<List<GetActorDto>>> GetActor()
    {
        var list = _mapper.Map<List<GetActorDto>>(await _context.Actors.ToListAsync());
        return new Response<List<GetActorDto>>(list);
    }

    public async Task<Response<List<GetCategoryDto>>> GetCategory()
    {
        var list = _mapper.Map<List<GetCategoryDto>>(await _context.Categories.ToListAsync());
        return new Response<List<GetCategoryDto>>(list);
    }

    public async Task<PaginationResponse<List<GetCategoryDto>>> GetMoviesByCategory(MovieFilter movieCategory)
    { 
        var find = await _context.Movies.ToListAsync();
        var list = new List<GetMovieDto>();

        movieCategory = new MovieFilter(movieCategory.Category, movieCategory.PageNumber, movieCategory.PageSize);
         
        var query = _context.Movies.AsQueryable();
            if(movieCategory.Name != null) query = query.Where(x => x.Title.Contains(movieCategory.Category));
            
            var filtered = await query.Skip((movieCategory.PageNumber - 1)* movieCategory.PageSize)
            .Take(movieCategory.PageSize).ToListAsync();

            var mapped = _mapper.Map<List<GetCategoryDto>>(filtered);
        var totalRecords = await _context.Movies.CountAsync();

        foreach(var f in find)
        {
            var movie = new GetMovieDto()
            {
                MovieId = f.MovieId,
                Title = f.Title,
                MovieYear = f.MovieYear
            };
            list.Add(movie);
        }

        return new PaginationResponse<List<GetCategoryDto>>(mapped, totalRecords, movieCategory.PageSize, movieCategory.PageNumber);
    }
}
