using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerRepository repository,IRepository<Customer> repo) : ControllerBase
{
    [HttpGet]
    public List<CustomerDto> GetAll()
    {
        var customers = repo.GetAll();
        var dtos = customers.Select(a => new CustomerDto
        {
            Id = a.Id.ToString(),
            Name = a.Name,
            Balance = a.Balance,
        }).ToList();
        return dtos;
    }
    [HttpGet("detail")]
    public List<CustomerDetailDto> GetAllDetail()
    {
        var customers = repository.GetAllDetail();
        var dto = customers.Select(a => new CustomerDetailDto
        {
            Id = a.Id.ToString(),
            Balance = a.Balance,
            Name = a.Name,
            User = new UserDto
            {
                Id = a.UserId,
                UserName = a.User.UserName

            }

        }).ToList();
        return dto;
    }

    [HttpPost]
    public void Create(CreateCustomerDto dto)
    {
        var customer = new Customer()
        {
            Name = dto.Name,
            Balance = dto.Balance,
            UserId = dto.UserId

        };
        repo.Create(customer);
    }
    [HttpGet("{id}")]
    public CustomerDto? Get(int id)
    {
        var customer = repo.Get(id);
        var dto = new CustomerDto()
        {
            Id = customer?.Id.ToString(),
            Name = customer.Name,
            Balance = customer.Balance

        };
        return dto;
    }
    [HttpGet("{id}/detail")]
    public CustomerDetailDto? GetDetail(int id)
    {
        var customer = repository.GetDetail(id);
        var dto = new CustomerDetailDto()
        {
            Id = customer.Id.ToString(),
            Name = customer.Name,
            Balance = customer.Balance,
            User = new UserDto()
            {
                Id = customer.User.Id,
                UserName = customer.User.UserName
            }

        };
        return dto;
    }

}
