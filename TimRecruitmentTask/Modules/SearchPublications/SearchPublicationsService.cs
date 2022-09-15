using PublicationServiceReference;

namespace TimRecruitmentTask.Modules.SearchPublications
{
    public interface ISearchPublicationsService
    {
        Task<string?> GetSearchResult(string searchedWord, string pageSize);
    }

    public class SearchPublicationsService : ISearchPublicationsService
    {
        private readonly WSCitationImpl _wcfClient;

        public SearchPublicationsService(WSCitationImpl wcfClient)
        {
            _wcfClient = wcfClient;
        }

        public async Task<string?> GetSearchResult(string searchedWord, string pageSize)
        {
            var requestQuery = new searchPublicationsRequest(queryString: searchedWord, resultType: null, cursorMark: "*", pageSize: pageSize, sort: null, synonym: null, email: null);
            var result = await _wcfClient.searchPublicationsAsync(requestQuery);

            var response = result.GetSearchResultFormatted();

            return (response?.Any() ?? true) ? string.Join(System.Environment.NewLine, response) : "Brak pasujących publikacji";
        }
    }
}
