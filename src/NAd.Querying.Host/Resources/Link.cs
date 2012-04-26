﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Xml.Serialization;

using NAd.Querying.Host.Infrastructure;

namespace NAd.Querying.Host.Resources
{
    [Serializable]
    public class Link
    {
        public Link(){}

        public Link(string uri, string relation, string mediaType)
        {
            Uri = uri;
            Relation = relation;
            MediaType = mediaType;
        }

        public static Link FromRelativeUri(string relativeRelationUri, string relativeUri, object args)
        {
            var baseUri = ConfigurationManager.AppSettings["baseUri"];
            var uri = UriHelper.ExcuteUriTemplate(baseUri, relativeUri, args);
            var relation = UriHelper.Combine(baseUri, relativeRelationUri);
            return new Link(uri, relation, MediaTypes.Default);
        }

        /// <summary>
        /// Indicates a resource with which the consumer can 
        /// interact to progress the application protocol.
        /// </summary>
        [XmlAttribute(AttributeName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The definitions of the markup values imply which HTTP verb 
        /// to use when following the link, as  well as required HTTP 
        /// headers, and the structure of the payload.
        /// </summary>
        [XmlAttribute(AttributeName = "rel")]
        public string Relation { get; set; }

        /// <summary>
        /// If a request requires an entity body, the link element will 
        /// contain a mediaType attribute that declares the format of the 
        /// request payload. If a request does not require an entity body, 
        /// the mediaType attribute will be absent.
        /// </summary>
        [XmlAttribute(AttributeName = "mediaType")]
        public string MediaType { get; set; }

        public override string ToString()
        {

            return string.Format("Media Type: {0}; Relation: {1}; Uri: {2}", MediaType, Relation, Uri);
        }

        #region Equality members
        public bool Equals(Link other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Uri, Uri) && Equals(other.Relation, Relation) && Equals(other.MediaType, MediaType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Link)) return false;
            return Equals((Link)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Uri != null ? Uri.GetHashCode() : 0);
                result = (result * 397) ^ (Relation != null ? Relation.GetHashCode() : 0);
                result = (result * 397) ^ (MediaType != null ? MediaType.GetHashCode() : 0);
                return result;
            }
        } 
        #endregion
    }
}