using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pipelines.Domain.DomainEntities;
using Pipelines.Domain.Repositories;
using Pipelines.Infra.Data.Context;
using Pipelines.Infra.Data.Models;

namespace Pipelines.Infra.Data.Repositories
{
    public abstract class Repository<TDomainEntity, TDataEntity> : IRepository<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TDataEntity : DataEntity
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        private readonly DbSet<TDataEntity> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        protected Repository(IDataContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _dbSet = _context.GetDbSet<TDataEntity>();
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            return _mapper.Map<IEnumerable<TDomainEntity>>(_dbSet);
        }

        public TDomainEntity GetById(Guid id)
        {
            return _mapper.Map<TDomainEntity>(_dbSet.Find(id));
        }

        public void Add(TDomainEntity entity)
        {
            var data = _mapper.Map<TDataEntity>(entity);
            _context.AddData(data);
        }

        public void Update(TDomainEntity entity)
        {
            var data = _mapper.Map<TDataEntity>(entity);
            _context.UpdateData(data);

            var entry = _context.GetDbEntry(data);
            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }

        public void Delete(Guid id)
        {
            var data = _dbSet.Find(id);

            if (data != null)
                _context.DeleteData(data);
        }
    }
}
