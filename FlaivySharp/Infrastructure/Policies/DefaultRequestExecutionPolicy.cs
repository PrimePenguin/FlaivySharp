using System.Threading.Tasks;

namespace FlaivySharp.Infrastructure.Policies
{
    public class DefaultRequestExecutionPolicy : IRequestExecutionPolicy
    {
        public async Task<T> Run<T>(CloneableRequestMessage request, ExecuteRequestAsync<T> executeRequestAsync)
        {
            return (await executeRequestAsync(request)).Result;
        }
    }
}