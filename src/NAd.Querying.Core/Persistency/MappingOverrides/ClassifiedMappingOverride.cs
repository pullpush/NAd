using NAd.Querying.Core.Domain;

using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NAd.Querying.Core.Persistency.MappingOverrides
{
    //http://jagregory.com/writings/fluent-nhibernate-auto-mapping-overrides-and-alterations/

    public class ClassifiedMappingOverride : IAutoMappingOverride<Classified>
    {
        public void Override(AutoMapping<Classified> mapping)
        {
            //http://wiki.fluentnhibernate.org/Fluent_mapping

            //In this example we're specifying that the Id property is mapped to an Id column in the database 
            //(could be another name using chain events .Column("AnotherColumnNameId")), 
            //and it's using an assigned generator.
            mapping.Id(x => x.Id).GeneratedBy.Assigned();

            //mapping.References(x => x.Attributes);
            /*
            mapping.Join("Attribute", m => 
            { 
                m.Fetch.Join();
                m.KeyColumn("Id");
                m.DynamicComponent(
                        x => x.Attributes,
                        part =>
                        {
                            // Works 
                            part.Map("Size").CustomType(typeof(string)).Nullable();
                            // Works 
                            var keySize = "Price";
                            part.Map(keySize).CustomType(typeof(float)).Nullable();

                            // Works 
                            part.References<string>(d => d["Picture"]);
                        });
            });
            */

            //http://stackoverflow.com/questions/1241005/how-to-join-table-in-fluent-nhibernate
            /*
            mapping.DynamicComponent(
                    x => x.Attributes,
                    part =>
                    {
                        // Works 
                        part.Map("Size").CustomType(typeof(string));
                        // Works 
                        var keySize = "Price";
                        part.Map(keySize).CustomType(typeof(float));
                        // Does not work 
                        //part.Map(d => d[keySize]).CustomType(typeof(string));

                        // Works 
                        part.References<string>(d => d["Picture"]);
                        // Does not work 
                        //var key = "Picture";
                        //part.References<Picture>(d => d[key]);
                    });
             */
        }
    }
}
