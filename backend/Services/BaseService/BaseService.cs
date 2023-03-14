using AutoMapper;
using Backend.Exceptions;
using Backend.Respositories.BaseRepo;

namespace Backend.Services.cs.BaseService
{
    public class BaseService<TModel, TReadDto, TCreateDto, TUpdateDto>
       : IBaseService<TModel, TReadDto, TCreateDto, TUpdateDto>
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepo<TModel> _repo;

        public BaseService(IMapper mapper, IBaseRepo<TModel> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<TReadDto> CreateOneAsync(TCreateDto create)
        {
            var entity = _mapper.Map<TCreateDto, TModel>(create);
            var result = await _repo.CreateOneAsync(entity);
            if (result is null)
            {
                throw new Exception("Cannot create");
            }
            return _mapper.Map<TModel, TReadDto>(result);
        }

        public Task<bool> DeleteOneAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TReadDto>> GetAllAsync(QueryOptions options)
        {
            var data = await _repo.GetAllAsync(options);
            return _mapper.Map<IEnumerable<TModel>, IEnumerable<TReadDto>>(data);
        }

        public async Task<TReadDto?> GetByIdAsync(string id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                throw new Exception("id is not found");
            }
            return _mapper.Map<TModel, TReadDto>(entity);
        }

        public async Task<TReadDto> UpdateOneAsync(string id, TUpdateDto update)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                throw HttpException.NotFound();
            }
            var result = await _repo.UpdateOneAsync(id, _mapper.Map<TUpdateDto, TModel>(update));
            return _mapper.Map<TModel, TReadDto>(result);
        }
    }
}