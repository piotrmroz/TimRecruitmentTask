using PublicationServiceReference;

namespace TimRecruitmentTask.Modules.SearchPublications
{
    public static class SearchPublicationsResponseExtension
    {
        public static string[]? GetSearchResultFormatted(this searchPublicationsResponse1 result)
        {
            return result?.@return.resultList.Select((item, index) => $"{index + 1}. {item.title}{Environment.NewLine}{item.authorString} {item.firstPublicationDate}{Environment.NewLine}").ToArray();
        }
    }
}
