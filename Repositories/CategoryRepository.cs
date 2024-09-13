using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using furniro_server.Data;
using furniro_server.Interfaces.Repositories;
using furniro_server.Models;
using furniro_server.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace furniro_server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly FurniroContext _context;

        public CategoryRepository(FurniroContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable<Category>>> GetAll(int skip, int take)
        {

            return await _context.Categories
                .OrderBy(c => c.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<Category> GetOne(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return category; 
        }

        public async Task<Category> Create(CategoryCreateDTO categoryDTO)
        {
            var category = new Category {
                Name = categoryDTO.Name,
                CoverPhoto = categoryDTO.CoverPhoto
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _context
                    .Categories
                    .Where(c => c.Id.Equals(id))
                    .ExecuteDeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;   
            }             
        }

        public async Task<Category?> Update(int id, CategoryCreateDTO categoryDTO)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category is null) return null;

            category.Name = categoryDTO.Name;
            category.CoverPhoto = categoryDTO.CoverPhoto;

            await _context.SaveChangesAsync();
            return category;
        }
    }
}