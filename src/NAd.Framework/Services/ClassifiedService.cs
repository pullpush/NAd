﻿using System;
using System.Collections.Generic;
using System.Linq;
using NAd.Common.Paging;
using NAd.Framework.Domain;
using NAd.Framework.Hive;


namespace NAd.Framework.Services
{
    public class ClassifiedService : IClassifiedService
    {
        //AI: Consider using a generic factory, but it's not in this class
        //This class itself will be generated by generic factory and not directly
        //
        //Generate generic factories with Autofac
        //http://peterspattern.com/generate-generic-factories-with-autofac/
        private readonly Func<NAdUnitOfWork> unitOfWorkFactory;

        public ClassifiedService(Func<NAdUnitOfWork> unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<Classified> GetClassifieds(string partialName, string partialDescription)
        {
            using (var uow = unitOfWorkFactory())
            {
                var classifieds = uow.Classifieds.FilterBy(
                        p => partialName.Length == 0 || (p.Name.Contains(partialName))
                          && partialDescription.Length == 0 || (p.Description.Contains(partialDescription))
                    ).AsPaged(1, 10);

                //AI: this approach is also valid
                //var classifieds = from classified in uow.Classifieds
                //       where (partialName.Length == 0 || (classified.Name.Contains(partialName)))
                //       where (partialDescription.Length == 0 || (classified.Description.Contains(partialDescription)))
                //       select classified;

                return classifieds.ToList().AsEnumerable();
            }
        }


        public Classified Get(Guid id)
        {
            return unitOfWorkFactory().Classifieds.Get(id);
        }

        public Classified GetByUrl(string url) {
            return (Classified)unitOfWorkFactory().Classifieds.GetPageByUrl(url);
        }

        public void Save(Classified classified)
        {
            using (var uow = unitOfWorkFactory())
            {
                uow.Classifieds.Save(classified);
                //uow.SubmitChanges();
            }
        }

        public bool CheckNotUniqueClassifiedName(string name)
        {
            return unitOfWorkFactory().Classifieds.Any(e => e.Name.Equals(name));
        }
    }
}