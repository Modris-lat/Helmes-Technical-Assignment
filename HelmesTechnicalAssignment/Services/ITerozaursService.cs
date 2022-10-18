using HelmesTechnicalAssignment.Models;

namespace HelmesTechnicalAssignment.Services
{
    public interface ITerozaursService
    {
        Task<List<TerozaursExample>> AnalyzeAsync(string word);
    }
}
