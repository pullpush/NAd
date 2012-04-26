using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

//using NAd.Querying.Core.Domain;

namespace NAd.Querying.Host.Resources.Classifieds.Representations
{
    [XmlRoot(ElementName = "classified", Namespace = "http://katyusha.com")]
    public class ClassifiedRepresentation : RepresentationBase
    {
        public ClassifiedRepresentation()
        {
            //Items = new List<OrderItemRepresentation>();
        }

        [XmlElement(ElementName = "id")]
        public Guid Id { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        //[XmlArray(ElementName = "items"), XmlArrayItem(ElementName = "item")]
        //public List<OrderItemRepresentation> Items { get; set; }

        //[XmlElement(ElementName = "status")]
        //[JsonConverter(typeof(StringEnumConverter))]
        //public OrderStatus Status { get; set; }
    }
}