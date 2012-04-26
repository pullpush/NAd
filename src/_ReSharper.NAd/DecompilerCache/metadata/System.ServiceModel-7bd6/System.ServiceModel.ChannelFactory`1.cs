// Type: System.ServiceModel.ChannelFactory`1
// Assembly: System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.ServiceModel.dll

using System;
using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel
{
    public class ChannelFactory<TChannel> : ChannelFactory, IChannelFactory<TChannel>, IChannelFactory,
                                            ICommunicationObject
    {
        protected ChannelFactory(System.Type channelType);
        public ChannelFactory();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ChannelFactory(string endpointConfigurationName);

        public ChannelFactory(string endpointConfigurationName, EndpointAddress remoteAddress);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ChannelFactory(Binding binding);

        public ChannelFactory(Binding binding, string remoteAddress);
        public ChannelFactory(Binding binding, EndpointAddress remoteAddress);
        public ChannelFactory(ServiceEndpoint endpoint);

        #region IChannelFactory<TChannel> Members

        public TChannel CreateChannel(EndpointAddress address);
        public virtual TChannel CreateChannel(EndpointAddress address, Uri via);

        #endregion

        public TChannel CreateChannel();
        protected override ServiceEndpoint CreateDescription();
        protected static TChannel CreateChannel(string endpointConfigurationName);
        public static TChannel CreateChannel(Binding binding, EndpointAddress endpointAddress);
        public static TChannel CreateChannel(Binding binding, EndpointAddress endpointAddress, Uri via);
    }
}
