/*******************************************************************************************
 * 
 * Auth: DRT
 * Date: 16/11/2025
 * 
 * Description: Interface for API service.
 * 
 ******************************************************************************************/

namespace APIConsumer
{
    public interface IApiService
    {
        Task<string> GetPostsAsync();
    }
}
