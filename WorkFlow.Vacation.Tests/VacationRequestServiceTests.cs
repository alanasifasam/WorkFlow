using AutoMapper;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using WorkFlow.Vacation.Application.Models.InputModels;
using WorkFlow.Vacation.Application.Models.OutputModels;
using WorkFlow.Vacation.Application.Services;
using WorkFlow.Vacation.Core.Entities;
using WorkFlow.Vacation.Core.Enums;
using WorkFlow.Vacation.Core.Interfaces;

namespace WorkFlow.Vacation.Tests
{
    public class VacationRequestServiceTests
    {
        private readonly Mock<IVacationRequestRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly VacationRequestService _service;

        public VacationRequestServiceTests()
        {
            _repositoryMock = new Mock<IVacationRequestRepository>();
            _mapperMock = new Mock<IMapper>();

           
            _mapperMock.Setup(m => m.Map<VacationRequestEntity>(It.IsAny<VacationRequestInputModel>()))
                       .Returns((VacationRequestInputModel src) => new VacationRequestEntity
                       {
                           CollaboratorId = src.CollaboratorId,
                           StartDate = src.StartDate,
                           EndDate = src.EndDate
                       });

            _mapperMock.Setup(m => m.Map<VacationRequestOutputModel>(It.IsAny<VacationRequestEntity>()))
                       .Returns((VacationRequestEntity src) => new VacationRequestOutputModel
                       {
                           CollaboratorId = src.CollaboratorId,
                           StartDate = src.StartDate,
                           EndDate = src.EndDate,
                           Status = src.Status
                       });

            _service = new VacationRequestService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact(DisplayName = "Sucesso - Deve criar solicitação de férias quando não há sobreposição")]
        public async Task CreateAsync_ShouldReturnApproved_WhenNoOverlap()
        {
            // Arrange
            _repositoryMock.Setup(r => r.HasOverlapAsync(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                           .ReturnsAsync(false);

            var input = new VacationRequestInputModel
            {
                CollaboratorId = 2,
                StartDate = DateOnly.Parse("2025-08-20"),
                EndDate = DateOnly.Parse("2025-08-25")
            };

            // Act
            var result = await _service.CreateAsync(input);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Solicitação de férias criada com sucesso.", result.Message);
            Assert.NotNull(result.Data);
            Assert.Equal(input.CollaboratorId, result.Data.CollaboratorId);
            Assert.Equal(input.StartDate, result.Data.StartDate);
            Assert.Equal(input.EndDate, result.Data.EndDate);

            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<VacationRequestEntity>()), Times.Once);
        }

        [Fact(DisplayName = "Erro - Deve retornar mensagem de erro quando há sobreposição")]
        public async Task CreateAsync_ShouldReturnError_WhenDatesOverlap()
        {
            // Arrange
            _repositoryMock.Setup(r => r.HasOverlapAsync(It.IsAny<DateOnly>(), It.IsAny<DateOnly>()))
                           .ReturnsAsync(true);

            var input = new VacationRequestInputModel
            {
                CollaboratorId = 2,
                StartDate = DateOnly.Parse("2025-08-03"),
                EndDate = DateOnly.Parse("2025-08-07")
            };

            // Act
            var result = await _service.CreateAsync(input);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(409, result.StatusCode);
            Assert.Equal("Já existe uma solicitação de férias para este período.", result.Message);
            Assert.Null(result.Data);

            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<VacationRequestEntity>()), Times.Never);
        }

        [Fact(DisplayName = "Erro - Deve rejeitar solicitação de férias.")]
        public async Task CreateAsync_ShouldReturnError_WhenAnaSilvaOverlapsMartaFernandes()
        {
            // Arrange
            _repositoryMock.Setup(r => r.HasOverlapAsync(
                    DateOnly.Parse("2025-08-14"),
                    DateOnly.Parse("2025-08-18")))
                .ReturnsAsync(true);

            var input = new VacationRequestInputModel
            {
                CollaboratorId = 1,
                StartDate = DateOnly.Parse("2025-08-14"),
                EndDate = DateOnly.Parse("2025-08-18")
            };

            // Act
            var result = await _service.CreateAsync(input);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal(409, result.StatusCode);
            Assert.Equal("Já existe uma solicitação de férias para este período.", result.Message);
            Assert.Null(result.Data);

            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<VacationRequestEntity>()), Times.Never);
        }

        [Fact(DisplayName = "Sucesso - Deve criar solicitação de férias para Marta Fernandes quando não há sobreposição")]
        public async Task CreateAsync_ShouldReturnApproved_WhenMartaFernandesHasNoOverlap()
        {
            // Arrange
            _repositoryMock.Setup(r => r.HasOverlapAsync(
                    DateOnly.Parse("2025-08-30"),
                    DateOnly.Parse("2025-09-05")))
                .ReturnsAsync(false);

            var input = new VacationRequestInputModel
            {
                CollaboratorId = 3,
                StartDate = DateOnly.Parse("2025-08-30"),
                EndDate = DateOnly.Parse("2025-09-05")
            };

            // Act
            var result = await _service.CreateAsync(input);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Solicitação de férias criada com sucesso.", result.Message);
            Assert.NotNull(result.Data);
            Assert.Equal(input.CollaboratorId, result.Data.CollaboratorId);
            Assert.Equal(input.StartDate, result.Data.StartDate);
            Assert.Equal(input.EndDate, result.Data.EndDate);

            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<VacationRequestEntity>()), Times.Once);
        }
    }
    
}