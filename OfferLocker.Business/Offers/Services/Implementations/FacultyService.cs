using OfferLocker.Business.Offers.Models.Faculty;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Extensions;
using System.Collections.Generic;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository repository;
        private readonly IMapper mapper;

        public FacultyService(IFacultyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<FacultyModel> Add(UpsertFacultyModel model)
        {
            var faculty = new Faculty(model.Name);

            await repository.Add(faculty);
            await repository.SaveChanges();

            return mapper.Map<FacultyModel>(faculty);
        }
        public async Task<PaginatedList<FacultyModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<Faculty>();

            var entities = await repository.Get(spec);
            var count = await repository.CountAsync();

            return new PaginatedList<FacultyModel>(
                model.PageIndex,
                entities.Count,
                count,
                mapper.Map<IList<FacultyModel>>(entities));
        }
        public async Task<FacultyModel> GetById(Guid id)
        {
            var faculty = await repository.GetById(id);

            return mapper.Map<FacultyModel>(faculty);
        }
        public async Task Update(Guid id, UpsertFacultyModel model)
        {
            var faculty = await repository.GetById(id);

            faculty.Update(model.Name);

            repository.Update(faculty);

            await repository.SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var faculty = await repository.GetById(id);

            repository.Delete(faculty);
            await repository.SaveChanges();
        }
    }
}
