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
    internal interface IApiService
    {
        Task<string?> GetStatusAsync();
    }
}
