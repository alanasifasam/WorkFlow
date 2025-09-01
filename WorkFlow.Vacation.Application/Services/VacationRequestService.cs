using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Enums;
using WorkFlow.Vacation.Core.Interfaces;

namespace WorkFlow.Vacation.Application.Services
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IVacationRequestRepository _repository;
        private readonly IMapper _mapper;

        public VacationRequestService(IVacationRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<VacationRequestOutputModel>> CreateAsync(VacationRequestInputModel input)
        {
            var entity = _mapper.Map<VacationRequestEntity>(input);
            
            bool hasOverlap = await _repository.HasOverlapAsync(
                input.StartDate,
                input.EndDate
            );

            if (hasOverlap)
            {
                return ServiceResponse<VacationRequestOutputModel>.Error(
                "Já existe uma solicitação de férias para este período.",
                409);
            }

            entity.Status = VacationRequestStatusEnum.Approved;
            await _repository.AddAsync(entity);

            var output = _mapper.Map<VacationRequestOutputModel>(entity);

            return ServiceResponse<VacationRequestOutputModel>.Ok(
                output,
                "Solicitação de férias criada com sucesso."
            );
        }

        public async Task<VacationRequestOutputModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<VacationRequestOutputModel>(entity);
        }

        public async Task<IEnumerable<VacationRequestOutputModel>> GetAllAsync(int? CollaboratorId = null, VacationRequestStatusEnum status = VacationRequestStatusEnum.None, DateOnly? startDate = null, DateOnly? endDate = null, int page = 1, int pageSize = 10)
        {
            var entities = await _repository.GetAllAsync(CollaboratorId, status, startDate, endDate, page, pageSize);
            return _mapper.Map<IEnumerable<VacationRequestOutputModel>>(entities); 
        }

        public async Task<ServiceResponse<VacationRequestOutputModel>> UpdateAsync(int id, VacationRequestInputModel input)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Pedido de férias não encontrado.");

            
            bool hasOverlap = await _repository.HasOverlapAsync(
                input.StartDate,
                input.EndDate
            );

            if (hasOverlap)
            {
                return ServiceResponse<VacationRequestOutputModel>.Error(
                "Já existe uma solicitação de férias para este período.",
                409);
            }

            entity.CollaboratorId = input.CollaboratorId;
            entity.StartDate = input.StartDate;
            entity.EndDate = input.EndDate;
            entity.Status = VacationRequestStatusEnum.Approved;
            

            await _repository.UpdateAsync(entity);
            var output = _mapper.Map<VacationRequestOutputModel>(entity);

            return ServiceResponse<VacationRequestOutputModel>.Ok(
                 output,
                 "Solicitação de férias atualizada com sucesso."
             );
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Pedido de férias não encontrado.");

            await _repository.DeleteAsync(entity);
        }
    }
}

