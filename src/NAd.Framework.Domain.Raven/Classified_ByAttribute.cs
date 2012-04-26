
using System.Linq;
using Lucene.Net.Documents;
using Raven.Client.Indexes;

namespace NAd.Framework.Domain.Raven
{
    public class Classified_ByAttribute : AbstractIndexCreationTask<Classified>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Classified_ByAttribute"/> class.
        /// </summary>
        /// <remarks>http://ravendb.net/docs/client-api/advanced/dynamic-fields</remarks>
        public Classified_ByAttribute()
                {
                    /*
                     * The underscore used for defining the index name is just a convention - 
                     * the call to .Select(at => new Field(...)) will generate index fields 
                     * based on the properties in the provided collection, without creating 
                     * any field with the name specified there, hence the underscore.
                     */
                    Map = classifieds => from classified in classifieds
                                         select new
                                                    {
                                                        _ = classified.StringAttributes.Select(attribute =>
                                                                                new Field(attribute.Name,
                                                                                          attribute.Value,
                                                                                          Field.Store.NO,
                                                                                          Field.Index.ANALYZED)),
                                                        __ = classified.IntegerAttributes.Select(attribute =>
                                                                                new NumericField(attribute.Name, 
                                                                                    attribute.Value, 
                                                                                    Field.Store.YES,
                                                                                    false)) //Field.Index.NOT_ANALYZED_NO_NORMS
                                                    };
                    /*
                     * After creating the index, we can easily look for documents using the attribute name 
                     * as a field to look on, as if it was a real object property. 
                     * Since it is not really a property, there is no Linq support for it, 
                     * hence it can only be queried using the LuceneQuery<>() API:
                     * var classifieds = session.Advanced.LuceneQuery<Classified>("Classified/ByAttribute")
                     *  .WhereEquals("Color", "Red")
                     *  .ToList();
                     */
                }
    }
}
