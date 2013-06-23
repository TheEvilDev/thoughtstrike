using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ideastrike.Models.Repositories;

namespace Ideastrike.MessageHandlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private readonly IUserRepository _users;

        public ApiKeyHandler(IUserRepository users)
        {
            _users = users;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage message)
        {
            var key = message.Headers.Authorization != null ? message.Headers.Authorization.Parameter : string.Empty;
            return _users.GetAll().AsEnumerable().Any(user => user.Id.ToString() == key);
        }
    }
}