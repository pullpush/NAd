using System;
using System.Collections;
using System.Dynamic;


namespace NAd.Querying.Core.Domain
{
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
