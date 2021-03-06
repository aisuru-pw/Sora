using System.Collections.Generic;
using Sora.Framework.Objects;

namespace Sora.EventArgs.BanchoEventArgs
{
    
    public class BanchoClientUserPresenceRequestArgs : IEventArgs, INeedPresence
    {
        public List<int> UserIds;
        public Presence Pr { get; set; }
    }
}