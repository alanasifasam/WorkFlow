using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;
using WorkFlow.Vacation.Core.Entities;

namespace WorkFlow.Vacation.Application.AutoMapper
{
    public class CollaboratorMapper : Profile
    {
        public CollaboratorMapper()
        {
            CreateMap<CollaboratorInputModel, CollaboratorEntity>();
            CreateMap<CollaboratorEntity, CollaboratorOutputModel>();
        }
    }
}
