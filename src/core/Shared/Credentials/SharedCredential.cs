using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Net.Core.Shared.Credentials;
public class SharedCredential : ICredential
{
    public SharedCredential(string id, string hostName)
    {
        Id = id;
        HostName = hostName;
    }

    public string Id { get; }
    public string HostName { get; }
}
