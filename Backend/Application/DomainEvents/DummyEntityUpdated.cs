using Core.Application;
using static Domain.Enums.Enums;

namespace Application.DomainEvents
{
    internal sealed class AutomovilUpdated : DomainEvent
    {
        public int DummyIdProperty { get; set; }
        public string DummyPropertyOne { get; set; }
        public DummyValues DummyPropertyTwo { get; set; }
    }
}
