
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NAd.Common
{
    public abstract class Descriptor<T>
    {
        protected Descriptor(T code)
        {
            Code = code;
        }

        /// <summary>
        /// Gets the underlying code represented by this descriptor.
        /// </summary>
        public T Code { get; private set; }

        /// <summary>
        /// Gets the name of the descriptor field.
        /// </summary>
        public string Name
        {
            get
            {
                var query =
                    from field in GetStaticFields(GetType())
                    let descriptor = (Descriptor<T>)field.GetValue(null)
                    where descriptor.Code.Equals(Code)
                    select field.Name;

                return query.Single();
            }
        }

        /// <summary>
        /// Returns the descriptor associated with the specified <paramref name="code"/>.
        /// </summary>
        public static TDescriptor FromCode<TDescriptor>(T code) where TDescriptor : Descriptor<T>
        {
            IEnumerable<FieldInfo> fields = GetStaticFields(typeof(TDescriptor));
            var descriptors = fields.Select(f => f.GetValue(null)).Cast<TDescriptor>();

            TDescriptor descriptor = descriptors.SingleOrDefault(d => d.Code.Equals(code));
            if (descriptor == null)
            {
                throw new ArgumentOutOfRangeException("code",
                    "The code " + code + " does not match a known " + typeof (TDescriptor).Name + ".");
            }

            return descriptor;
        }

        public static IEnumerable<TDescriptor> GetAll<TDescriptor>() where TDescriptor : Descriptor<T>
        {
            IEnumerable<FieldInfo> fields = GetStaticFields(typeof(TDescriptor));
            return fields.Select(f => f.GetValue(null)).Cast<TDescriptor>();
        } 

        protected static IEnumerable<FieldInfo> GetStaticFields(Type type)
        {
            return type.GetFields(BindingFlags.Static | BindingFlags.Public);
        }

        /// <summary>
        ///     Determines whether the specified <see cref = "System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name = "obj">The <see cref = "System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref = "System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref = "T:System.NullReferenceException">
        ///     The <paramref name = "obj" /> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            var other = obj as Descriptor<T>;
            return (other != null) && (Code.Equals(other.Code));
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        /// <summary>
        ///     Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Descriptor<T> a, Descriptor<T> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Code.Equals(b.Code);
        }

        public static bool operator !=(Descriptor<T> a, Descriptor<T> b)
        {
            return !(a == b);
        }
    }

    public abstract class Descriptor : Descriptor<string>
    {
        protected Descriptor(string value) : base(value)
        {
        }
    }
}