using RestEase;
using RestEaseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestEaseTest
{
    [Header("User-Agent", "RestEase Sample")]
    public interface IGithubClient
    {
        [Get("users/{username}")]
        Task<GithubUser> GetUserAsync([Path("username")] string username,CancellationToken cancellationtoken);
    }

}
