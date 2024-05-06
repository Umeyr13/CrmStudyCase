using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private readonly UserManager<AppUser> _userManager;

        public SuggestionService(ISuggestionRepository suggestionRepository, UserManager<AppUser> userManager)
        {
            _suggestionRepository = suggestionRepository;
            _userManager = userManager;
        }

        public async Task<Suggestion> CreateSuggestion(Suggestion suggestion)
        {
            var result =await   _suggestionRepository.AddAsync(suggestion);
    
                return suggestion;

        }

        public Task<bool> DeleteSuggestionAsync(int suggestionId)
        {
            return _suggestionRepository.RemoveIdAsync(suggestionId);
        }

        public Task<List<Suggestion>> GetAllSuggestionAsync(ClaimsPrincipal employee)
        {
            int employeeId = int.Parse(_userManager.GetUserId(employee));
            var data = _suggestionRepository.Table
                .Where(s=> s.EmployeeId == employeeId)
                .Include(s=>s.Customer)
                .Include(s=>s.Sale).ToListAsync();
            return data;
        }

        public Task<Suggestion> GetSuggestionByIdAsync(int suggestionId)
        {
            return _suggestionRepository.GetByIdAsync(suggestionId);
        }

        public  async Task<bool> UpdateSuggestion(Suggestion suggestion)
        {
            var sug = await _suggestionRepository.Find(c => c.SuggestionId == suggestion.SuggestionId).FirstOrDefaultAsync();
            if (sug != null)
            {
                sug.Subject = suggestion.Subject;
                sug.Description = suggestion.Description;
                await _suggestionRepository.SaveAsync();
                return true;
            }
           return false;
        }
    }
}
