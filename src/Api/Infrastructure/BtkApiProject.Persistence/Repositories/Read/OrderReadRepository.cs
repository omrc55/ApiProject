﻿using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Domain.Entities;
using BtkApiProject.Persistence.Contexts;
using BtkApiProject.Persistence.Repositories.Generic;

namespace BtkApiProject.Persistence.Repositories.Read;

public class OrderReadRepository(CustomDbContext context) : ReadRepository<Order>(context), IOrderReadRepository { }