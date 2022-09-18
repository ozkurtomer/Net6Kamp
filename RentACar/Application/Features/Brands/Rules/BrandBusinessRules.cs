using Domain.Entities;
using Core.Persistence.Paging;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    private readonly IBrandRepository BrandRepository;
    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        BrandRepository = brandRepository;
    }

    public async Task BrandNameConNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Brand> result = await BrandRepository.GetListAsync(x => x.Name == name);
        if (result.Items.Any())
            throw new BusinessException("Brand name exists");
    }
}
