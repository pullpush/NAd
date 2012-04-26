// Type: Autofac.RegistrationExtensions
// Assembly: Autofac, Version=2.5.2.830, Culture=neutral, PublicKeyToken=17863af14b0044da
// Assembly location: D:\Projects\Workshop\NAd\packages\Autofac.2.5.2.830\lib\NET40\Autofac.dll

using Autofac.Builder;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using Autofac.Features.LightweightAdapters;
using Autofac.Features.OpenGenerics;
using Autofac.Features.Scanning;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Autofac
{
    public static class RegistrationExtensions
    {
        public static void RegisterModule(this ContainerBuilder builder, IModule module);
        public static void RegisterModule<TModule>(this ContainerBuilder builder) where TModule : new(), IModule;
        public static void RegisterComponent(this ContainerBuilder builder, IComponentRegistration registration);
        public static void RegisterSource(this ContainerBuilder builder, IRegistrationSource registrationSource);

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterInstance<T>(
            this ContainerBuilder builder, T instance) where T : class;

        public static IRegistrationBuilder<TImplementor, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterType<TImplementor>(this ContainerBuilder builder);

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterType(this ContainerBuilder builder, Type implementationType);

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> Register<T>(
            this ContainerBuilder builder, Func<IComponentContext, T> @delegate);

        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> Register<T>(
            this ContainerBuilder builder, Func<IComponentContext, IEnumerable<Parameter>, T> @delegate);

        public static IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle> RegisterGeneric(
            this ContainerBuilder builder, Type implementor);

        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> PreserveExistingDefaults
            <TLimit, TActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration)
            where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<TLimit, ScanningActivatorData, TRegistrationStyle> PreserveExistingDefaults
            <TLimit, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, ScanningActivatorData, TRegistrationStyle> registration);

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            RegisterAssemblyTypes(this ContainerBuilder builder, params Assembly[] assemblies);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> Where
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, bool> predicate) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> As
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, IEnumerable<Service>> serviceMapping) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> As
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, Service> serviceMapping) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> As
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, Type> serviceMapping) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> As
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, IEnumerable<Type>> serviceMapping) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle> AsSelf<TLimit>(
            this IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> AsSelf
            <TLimit, TConcreteActivatorData>(
            this IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> registration)
            where TConcreteActivatorData : IConcreteActivatorData;

        public static IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> AsSelf<TLimit>(
            this IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> WithMetadata
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, IEnumerable<KeyValuePair<string, object>>> metadataMapping)
            where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> WithMetadataFrom
            <TAttribute>(this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> WithMetadata
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            string metadataKey, Func<Type, object> metadataValueMapping)
            where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Named<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration,
            Func<Type, string> serviceNameMapping);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> Named
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, string> serviceNameMapping, Type serviceType)
            where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Keyed<TService>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration,
            Func<Type, object> serviceKeyMapping);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> Keyed
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Func<Type, object> serviceKeyMapping, Type serviceType) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle>
            AsImplementedInterfaces<TLimit>(
            this IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle>
            AsImplementedInterfaces<TLimit, TConcreteActivatorData>(
            this IRegistrationBuilder<TLimit, TConcreteActivatorData, SingleRegistrationStyle> registration)
            where TConcreteActivatorData : IConcreteActivatorData;

        public static IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle>
            AsImplementedInterfaces<TLimit>(
            this IRegistrationBuilder<TLimit, ReflectionActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> FindConstructorsWith
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, BindingFlags bindingFlags)
            where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> FindConstructorsWith
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
            IConstructorFinder constructorFinder) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> UsingConstructor
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, params Type[] signature)
            where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> UsingConstructor
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
            IConstructorSelector constructorSelector) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithParameter
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, string parameterName,
            object parameterValue) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithParameter
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, Parameter parameter)
            where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithParameter
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
            Func<ParameterInfo, IComponentContext, bool> parameterSelector,
            Func<ParameterInfo, IComponentContext, object> valueProvider)
            where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithParameters
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
            IEnumerable<Parameter> parameters) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithProperty
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, string propertyName,
            object propertyValue) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithProperty
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration, Parameter property)
            where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> WithProperties
            <TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit, TReflectionActivatorData, TStyle> registration,
            IEnumerable<Parameter> properties) where TReflectionActivatorData : ReflectionActivatorData;

        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> Targeting
            <TLimit, TActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration,
            IComponentRegistration target) where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> OnRegistered
            <TLimit, TActivatorData, TSingleRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration,
            Action<ComponentRegisteredEventArgs> handler) where TSingleRegistrationStyle : SingleRegistrationStyle;

        public static IRegistrationBuilder<TLimit, ScanningActivatorData, TRegistrationStyle> OnRegistered
            <TLimit, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, ScanningActivatorData, TRegistrationStyle> registration,
            Action<ComponentRegisteredEventArgs> handler);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> AsClosedTypesOf
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration,
            Type openGenericServiceType) where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> AssignableTo
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration, Type type)
            where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> AssignableTo<T>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Except<T>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> Except<T>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration,
            Action<IRegistrationBuilder<T, ConcreteReflectionActivatorData, SingleRegistrationStyle>>
                customisedRegistration);

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> InNamespaceOf<T>(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration);

        public static IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> InNamespace
            <TLimit, TScanningActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TScanningActivatorData, TRegistrationStyle> registration, string ns)
            where TScanningActivatorData : ScanningActivatorData;

        public static IRegistrationBuilder<TTo, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterAdapter<TFrom, TTo>(this ContainerBuilder builder,
                                        Func<IComponentContext, IEnumerable<Parameter>, TFrom, TTo> adapter);

        public static IRegistrationBuilder<TTo, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterAdapter<TFrom, TTo>(this ContainerBuilder builder, Func<IComponentContext, TFrom, TTo> adapter);

        public static IRegistrationBuilder<TTo, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterAdapter<TFrom, TTo>(this ContainerBuilder builder, Func<TFrom, TTo> adapter);

        public static IRegistrationBuilder<object, OpenGenericDecoratorActivatorData, DynamicRegistrationStyle>
            RegisterGenericDecorator(this ContainerBuilder builder, Type decoratorType, Type decoratedServiceType,
                                     object fromKey, object toKey = null);

        public static IRegistrationBuilder<TService, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterDecorator<TService>(this ContainerBuilder builder,
                                        Func<IComponentContext, IEnumerable<Parameter>, TService, TService> decorator,
                                        object fromKey, object toKey = null);

        public static IRegistrationBuilder<TService, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterDecorator<TService>(this ContainerBuilder builder,
                                        Func<IComponentContext, TService, TService> decorator, object fromKey,
                                        object toKey = null);

        public static IRegistrationBuilder<TService, LightweightAdapterActivatorData, DynamicRegistrationStyle>
            RegisterDecorator<TService>(this ContainerBuilder builder, Func<TService, TService> decorator,
                                        object fromKey, object toKey = null);

        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> OnRelease
            <TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration,
            Action<TLimit> releaseAction);
    }
}
