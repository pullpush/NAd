// Type: Lucene.Net.Documents.Field
// Assembly: Lucene.Net, Version=2.9.4.1, Culture=neutral, PublicKeyToken=85089178b9ac3181
// Assembly location: D:\Projects\Workshop\NAd\packages\RavenDB.1.0.701\server\Lucene.Net.dll

using Lucene.Net.Analysis;
using Lucene.Net.Util;
using System;
using System.IO;

namespace Lucene.Net.Documents
{
    [Serializable]
    public sealed class Field : AbstractField, Fieldable
    {
        public Field(string name, string value_Renamed, Field.Store store, Field.Index index);

        public Field(string name, string value_Renamed, Field.Store store, Field.Index index,
                     Field.TermVector termVector);

        public Field(string name, bool internName, string value_Renamed, Field.Store store, Field.Index index,
                     Field.TermVector termVector);

        public Field(string name, TextReader reader);
        public Field(string name, TextReader reader, Field.TermVector termVector);
        public Field(string name, TokenStream tokenStream);
        public Field(string name, TokenStream tokenStream, Field.TermVector termVector);
        public Field(string name, byte[] value_Renamed, Field.Store store);
        public Field(string name, byte[] value_Renamed, int offset, int length, Field.Store store);

        #region Fieldable Members

        public override string StringValue();
        public override TextReader ReaderValue();

        [Obsolete(
            "This method must allocate a new byte[] if the AbstractField.GetBinaryOffset() is non-zero or AbstractField.GetBinaryLength() is not the full length of the byte[]. Please use AbstractField.GetBinaryValue() instead, which simply returns the byte[]."
            )]
        public override byte[] BinaryValue();

        public override TokenStream TokenStreamValue();

        #endregion

        public void SetValue(string value_Renamed);
        public void SetValue(TextReader value_Renamed);
        public void SetValue(byte[] value_Renamed);
        public void SetValue(byte[] value_Renamed, int offset, int length);

        [Obsolete("use SetTokenStream ")]
        public void SetValue(TokenStream value_Renamed);

        public void SetTokenStream(TokenStream tokenStream);

        #region Nested type: Index

        [Serializable]
        public sealed class Index : Parameter
        {
            public static readonly Field.Index NO;
            public static readonly Field.Index ANALYZED;
            [Obsolete("this has been renamed to ANALYZED")] public static readonly Field.Index TOKENIZED;
            public static readonly Field.Index NOT_ANALYZED;
            [Obsolete("This has been renamed to NOT_ANALYZED")] public static readonly Field.Index UN_TOKENIZED;
            public static readonly Field.Index NOT_ANALYZED_NO_NORMS;
            [Obsolete("This has been renamed to NOT_ANALYZED_NO_NORMS")] public static readonly Field.Index NO_NORMS;
            public static readonly Field.Index ANALYZED_NO_NORMS;
        }

        #endregion

        #region Nested type: Store

        [Serializable]
        public sealed class Store : Parameter
        {
            public static readonly Field.Store COMPRESS;
            public static readonly Field.Store YES;
            public static readonly Field.Store NO;
        }

        #endregion

        #region Nested type: TermVector

        [Serializable]
        public sealed class TermVector : Parameter
        {
            public static readonly Field.TermVector NO;
            public static readonly Field.TermVector YES;
            public static readonly Field.TermVector WITH_POSITIONS;
            public static readonly Field.TermVector WITH_OFFSETS;
            public static readonly Field.TermVector WITH_POSITIONS_OFFSETS;
        }

        #endregion
    }
}
