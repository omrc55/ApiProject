﻿using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Domain.Entities;
using BtkApiProject.Persistence.Contexts;
using BtkApiProject.Persistence.Repositories.Generic;

namespace BtkApiProject.Persistence.Repositories.Write;

public class CategoryWriteRepository(CustomDbContext context) : WriteRepository<Category>(context), ICategoryWriteRepository { }