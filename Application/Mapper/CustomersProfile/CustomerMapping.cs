﻿using Application.DTOs.Customer;
using AutoMapper;
using Domain.entities;

namespace Application.Mapper.CustomersProfile

{
    internal class CustomerMapping : Profile
    {
      

        public void ApplyMapping()
        {
            CreateMap<Customer, CustomerDto>();

        }
    }
}
