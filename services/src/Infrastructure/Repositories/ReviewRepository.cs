﻿using Domain.Common.Pagination.Request;
using Domain.Common.Pagination.Response;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReviewRepository : BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context) { }
    
    public async Task<Page<Review>> GetAllForFuelStationAsync(long fuelStationId, PageRequest<Review> pageRequest)
    {
        IQueryable<Review> query = Context.Reviews
            .Include(r => r.User)
            .Where(r => r.FuelStationId == fuelStationId);
        
        return await Paginate(query, pageRequest);
    }
}