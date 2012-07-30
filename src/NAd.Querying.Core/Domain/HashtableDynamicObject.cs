using System;
using System.Collections;
using System.Dynamic;


namespace NAd.Querying.Core.Domain
{
    /// <summary>
    /// search for support dynamic fields in nhibernate, eav model in NH
    /// </summary>
    /// <see cref="http://ayende.com/blog/4776/support-dynamic-fields-with-nhibernate-and-net-4-0"/>
    /// <seealso cref="http://stackoverflow.com/questions/2784547/using-nhibernate-with-an-eav-data-model"/>
    public class HashtableDynamicObject : DynamicObject
    {
        private readonly IDictionary _dictionary;

        public HashtableDynamicObject(IDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _dictionary[binder.Name];
            return _dictionary.Contains(binder.Name);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes == null)
                throw new ArgumentNullException("indexes");
            if (indexes.Length != 1)
                throw new ArgumentException("Only support a single indexer parameter", "indexes");
            result = _dictionary[indexes[0]];
            return _dictionary.Contains(indexes[0]);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {

            if (indexes == null)
                throw new ArgumentNullException("indexes");
            if (indexes.Length != 1)
                throw new ArgumentException("Only support a single indexer parameter", "indexes");
            _dictionary[indexes[0]] = value;
            return true;
        }
    }
}
