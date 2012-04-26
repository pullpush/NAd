// Type: Autofac.Builder.RegistrationExtensions
// Assembly: Autofac, Version=2.5.2.830, Culture=neutral, PublicKeyToken=17863af14b0044da
// Assembly location: D:\Projects\Workshop\NAd\packages\Autofac.2.5.2.830\lib\NET40\Autofac.dll

using Autofac;
using Autofac.Core;
using Autofac.Features.GeneratedFactories;
using System;

namespace Autofac.Builder
{
    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<Delegate, GeneratedFactoryActivatorData, SingleRegistrationStyle>
            RegisterGeneratedFactory(this ContainerBuilder builder, Type delegateType);

        public static IRegistrationBuilder<Delegate, GeneratedFactoryActivatorData, SingleRegistrationStyle>
            RegisterGeneratedFactory(this ContainerBuilder builder, Type delegateType, Service service);

        public static IRegistrationBuilder<TDelegate, GeneratedFactoryActivatorData, SingleRegistrationStyle>
            RegisterGeneratedFactory<TDelegate>(this ContainerBuilder builder, Service service) where TDelegate : class;

        public static IRegistrationBuilder<TDelegate, GeneratedFactoryActivatorData, SingleRegistrationStyle>
            RegisterGeneratedFactory<TDelegate>(this ContainerBuilder builder) where TDelegate : class;

        public static IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>
            NamedParameterMapping<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle> registration)
            where TGeneratedFactoryActivatorData : GeneratedFactoryActivatorData
            where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>
            PositionalParameterMapping<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle> registration)
            where TGeneratedFactoryActivatorData : GeneratedFactoryActivatorData
            where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>
            TypedParameterMapping<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TDelegate, TGeneratedFactoryActivatorData, TSingleRegistrationStyle> registration)
            where TGeneratedFactoryActivatorData : GeneratedFactoryActivatorData
            where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<object[], SimpleActivatorData, SingleRegistrationStyle> RegisterCollection(
            this ContainerBuilder builder, string collectionName, Type elementType);

        public static IRegistrationBuilder<T[], SimpleActivatorData, SingleRegistrationStyle> RegisterCollection<T>(
            this ContainerBuilder builder, string collectionName);

        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> MemberOf
            <TLimit, TActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration,
            string collectionName) where TSingleRegistrationStyle : SingleRegistrationStyle;
    }
}
