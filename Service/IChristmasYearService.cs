using RefactorBEcapstone.Models;
using RefactorBEcapstone.Year.Requests;
using RefactorBEcapstone.Year.Responses;

namespace RefactorBEcapstone.Service
{
    public interface IChristmasYearService
    {
        Task<YearResponse> CreateChristmasYear(CreateYearRequest yearRequest);
        Task<List<YearResponse>> GetAllYears();
    }
}
