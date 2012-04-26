using System;
using System.Collections.Generic;
using Autofac;
using NAd.Framework.Domain;
using NAd.Framework.Hive;
using NAd.Framework.Hive.NHibernate;
using NAd.Framework.Hive.Raven;
using NAd.Framework.Services;
using NUnit.Framework;
using NUnit;
using FluentAssertions;

namespace NAd.Framework.Specs
{
    [TestFixture]
    public class ClassifiedRepositoryTest
    {

        [Test]
        public void test_classified_nh_repository()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new NHibernateUnitOfWorkModule("QueryContext"));
            //containerBuilder.RegisterType<ClassifiedService>().As<IClassifiedService>();
            var container = containerBuilder.Build();

            var classifiedService = new ClassifiedService(container.Resolve<Func<NAdUnitOfWork>>());

            var target = classifiedService.Get(Guid.Empty);

            //target = classifiedService.Get(Guid.NewGuid());


            //target.Should().BeNull();

            using (var uow = container.Resolve<Func<NAdUnitOfWork>>()())
            {
                //-----------------------------------------------------------------------------------------------------------
                // Act
                //-----------------------------------------------------------------------------------------------------------
                Action action = () => uow.Classifieds.Add(new Classified
                {
                    CreatedDate = DateTime.Now,
                    Name = "Just another name",
                    Description = "My Night",
                    Id = Guid.NewGuid()
                });

                action();

                uow.SubmitChanges();
            }
        }

        [Test]
        public void test_classified_raven_repository()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new RavenUnitOfWorkModule("http://localhost:8080"));
            //containerBuilder.RegisterType<ClassifiedService>().As<IClassifiedService>();
            var container = containerBuilder.Build();

            var classifiedService = new ClassifiedService(container.Resolve<Func<NAdUnitOfWork>>());

            var target = classifiedService.Get(Guid.Empty);

            //target = classifiedService.Get(Guid.NewGuid());



            //target.Should().BeNull();


            using (var uow = container.Resolve<Func<NAdUnitOfWork>>()())
            {
                //var classifieds = session.Advanced.LuceneQuery<Classified>("Classified/ByAttribute")
                //    .WhereEquals("Color", "Red")
                //    .ToList();

                //-----------------------------------------------------------------------------------------------------------
                // Act
                //-----------------------------------------------------------------------------------------------------------
                var strAttr = new List<AttributeValue<string>>();
                strAttr.Add(new AttributeValue<string>() { Name = "Color", Value = "Green"});
                strAttr.Add(new AttributeValue<string>() { Name = "Condition", Value = "Excellent" });

                Action action = () => uow.Classifieds.Add(new Classified
                                                              {
                                                                  CreatedDate = DateTime.Now, 
                                                                  Name = "Apple",
                                                                  Description = "My Night",
                                                                  Id = Guid.NewGuid(),
                                                                  StringAttributes = strAttr
                                                              });

                action();

                uow.SubmitChanges();

                //var t = uow.Classifieds.List();
                //var target2 = uow.Classifieds.FindBy(p => p.Name == "Crazy Name");

                //var target2 = uow.Classifieds.GetByName(Guid.Empty);

                //-----------------------------------------------------------------------------------------------------------
                // Assert
                //-----------------------------------------------------------------------------------------------------------
                //action.ShouldViolate(CookbookRule.RecipeTitleMustBeShort);
                //target2.Should().BeNull();
            }
        }
    }
}
