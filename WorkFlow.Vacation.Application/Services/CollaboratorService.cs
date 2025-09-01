using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Interfaces;

namespace WorkFlow.Vacation.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _repository;
        private readonly IMapper _mapper;
        public CollaboratorService(ICollaboratorRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;   
        }
        public async Task CreateAsync(CollaboratorInputModel input)
        {
            var collaborator = _mapper.Map<CollaboratorEntity>(input);
            await _repository.AddAsync(collaborator); 
            return;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CollaboratorOutputModel>> GetAllAsync(string? name = null, string? email = null, int page = 1, int pageSize = 10)
        {
           var entities = await _repository.GetAllAsync(name,email,page,pageSize);
            return _mapper.Map<IEnumerable<CollaboratorOutputModel>>(entities);
        }

        public async Task<CollaboratorOutputModel?> GetByIdAsync(int id)
        {
            var collaborator = await _repository.GetByIdAsync(id);
            if (collaborator == null) return null;
            return _mapper.Map<CollaboratorOutputModel>(collaborator);
        }

        public async Task<CollaboratorOutputModel?> UpdateAsync(int id, CollaboratorInputModel input)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(input, existing);
            var entity = await _repository.UpdateAsync(existing);
            return _mapper.Map<CollaboratorOutputModel>(entity);
        }
    }
}
