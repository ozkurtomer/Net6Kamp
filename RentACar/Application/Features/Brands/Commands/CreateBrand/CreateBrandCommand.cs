using MediatR;
using AutoMapper;
using Domain.Entities;
using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using Application.Features.Brands.Rules;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<CreatedBrandDto>
{
    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
    {
        private readonly IBrandRepository BrandRepository;
        private IMapper Mapper;
        private readonly BrandBusinessRules BrandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            BrandRepository = brandRepository;
            Mapper = mapper;
            BrandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await BrandBusinessRules.BrandNameConNotBeDuplicatedWhenInserted(request.Name);

            Brand mappedBrand = Mapper.Map<Brand>(request);
            Brand createdBrand = await BrandRepository.AddAsync(mappedBrand);

            CreatedBrandDto createdBrandDto = Mapper.Map<CreatedBrandDto>(createdBrand);
            return createdBrandDto;
        }
    }


}
