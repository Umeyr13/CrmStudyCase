using CustomerRelationsManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IServices
{
    public interface ISuggestionService
    {
		Task<List<Suggestion>> GetAllSuggestionAsync(ClaimsPrincipal employee);
        Task<Suggestion> GetSuggestionByIdAsync(int suggestionId);
        Task<Suggestion> CreateSuggestion(Suggestion suggestion);
        Task<bool> UpdateSuggestion(Suggestion suggestion);
        Task<bool> DeleteSuggestionAsync(int suggestionId);
        
    }
}
