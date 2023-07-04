using System.Runtime.Serialization;

namespace Dummy.Impl
{
    public enum Status
    {
        [EnumMember(Value = "POISONED")]
        POISONED,

        [EnumMember(Value = "INVINCIBLE")]
        INVINCIBLE
    }
}
