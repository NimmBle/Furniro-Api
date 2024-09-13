using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using furniro_server.Models;
using furniro_server.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace furniro_server.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<ActionResult<IEnumerable<Category>>> GetAll(int skip, int take);
        Task<Category> GetOne(int id);
        Task<Category> Create(CategoryCreateDTO categoryDTO);
        Task<Category?> Update(int id, CategoryCreateDTO categoryDTO);
        Task<bool> Delete(int id);
    }
}