﻿using Application.DTOs.Inventory;
using MediatR;


namespace Application.Moduels.Inventory.Queries
{
    public class Queries
    {
        public record GetInventoryByIdQuery(int Id) : IRequest<InventoryDto>;
        public record GetAllInventoriesQuery : IRequest<IReadOnlyCollection<InventoryDto>>;

    }
}
