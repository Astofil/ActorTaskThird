using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Context;
using Infrastructure.Seeds;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController
{
    private readonly MovieService _movieService;
    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("GetMoviesByName")]
    public async Task<PaginationResponse<List<GetMovieDto>>> GetMovieByName([FromQuery]MovieFilter movieName)
    {
        return await _movieService.GetMoviesByName(movieName);
    }

    [HttpGet("GetActors")]
    public async Task<Response<List<GetActorDto>>> GetActor()
    {
        return await _movieService.GetActor();
    }
    
    [HttpGet("GetCategories")]
    public async Task<Response<List<GetCategoryDto>>> GetCategory()
    {
        return await _movieService.GetCategory();
    }

    [HttpGet("GetMoviesByCategory")]
    public async Task<PaginationResponse<List<GetCategoryDto>>> GetMovieByCategory([FromQuery]MovieFilter movieCategory)
    {
        return await _movieService.GetMoviesByCategory(movieCategory);
    }
}
