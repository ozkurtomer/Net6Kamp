using AutoMapper;
using Domain.Entities;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Commands.CreateBrand;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Brand, CreatedBrandDto>().ReverseMap();
		CreateMap<Brand, CreateBrandCommand>().ReverseMap();
	}
}
