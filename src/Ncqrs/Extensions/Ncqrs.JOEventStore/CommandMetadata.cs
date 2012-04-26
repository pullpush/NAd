using System;

namespace Ncqrs.JOEventStore
{
    public class CommandMetadata
    {
        public Guid CommandId { get; set; }
        public int? LastKnownRevision { get; set; }
        public Guid TargetId { get; set; }
        public Type TargetType { get; set; }
        public bool TargetExists { get; set; }
    }
}