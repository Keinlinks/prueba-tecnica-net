
namespace Clients.Dtos
{
    public record PaginationDto<T>(int Page, int PageSize, int TotalRecords, List<T> Data);
}
