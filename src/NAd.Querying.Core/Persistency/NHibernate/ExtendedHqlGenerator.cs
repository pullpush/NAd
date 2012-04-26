using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace NAd.Services.Core.Persistency.NHibernate
{
    /// <summary>
    /// Custom extension to compensate for NH 3.0.0 lack of support for Equals in LINQ queries.
    /// </summary>
    /// <remarks>
    /// See <seealso href="http://wordpress.primordialcode.com/index.php/2010/08/13/nhibernate-3-extending-linq-provider-fix-notsupportedexception/"/>
    /// </remarks>
    internal class EqualsHqlGeneratorForMethod : BaseHqlGeneratorForMethod
    {
        public EqualsHqlGeneratorForMethod()
        {
            // the methods call are used only to get info about the signature, the actual parameter is just ignored
            SupportedMethods = new[]
            {
                ReflectionHelper.GetMethodDefinition<Byte>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<SByte>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Int16>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Int32>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Int64>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<UInt16>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<UInt32>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<UInt64>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Single>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Double>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Boolean>(x => x.Equals(true)),
                ReflectionHelper.GetMethodDefinition<Char>(x => x.Equals((Char)0)),
                ReflectionHelper.GetMethodDefinition<Decimal>(x => x.Equals(0)),
                ReflectionHelper.GetMethodDefinition<Guid>(x => x.Equals(Guid.Empty)),
                ReflectionHelper.GetMethodDefinition<object>(x => x.Equals(new object())),
            };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
            ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Equality(
                visitor.Visit(targetObject).AsExpression(),
                visitor.Visit(arguments[0]).AsExpression());
        }
    }

    internal class EqualsLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public EqualsLinqToHqlGeneratorsRegistry()
        {
            this.Merge(new EqualsHqlGeneratorForMethod());
        }
    }
}