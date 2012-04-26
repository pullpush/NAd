// Type: System.ValueType
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
    [ComVisible(true)]
    [Serializable]
    public abstract class ValueType
    {
        public override bool Equals(object obj);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override int GetHashCode();

        public override string ToString();
    }
}
