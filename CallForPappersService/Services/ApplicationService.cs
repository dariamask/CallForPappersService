﻿using CallForPappersService.Data.Dto;
using CallForPappersService.Data.Entities;
using CallForPappersService.Repository;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace CallForPappersService.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(IApplicationRepository applicationRepository, IActivityRepository activityRepository, ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _activityRepository = activityRepository;
            _logger = logger;
        }
        public async Task<ApplicationDto> CreateApplicationAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(dto);

            // проверить createDto

            var application = new Application
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name!,
                Description = dto.Description!,
                Outline = dto.Outline!,
                CreatedDate = DateTime.Now,
                Status = ApplicationStatus.Active,
                ActivityId = _activityRepository.GetActivity(dto.ActvityTypeName).Id,
            };

            _applicationRepository.CreateApplication(application);

            return new ApplicationDto()
            {
                Id = Guid.NewGuid(),
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType,              
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }

        public async Task<ApplicationDto> GetApplicationAsync(Guid applicationId)
        {
            var application = _applicationRepository.GetApplication(applicationId);

            

             return new ApplicationDto()
            {
                Id = application.Id,
                AuthorId = application.AuthorId,
                ActvityTypeName = application.Activity.ActivityType,
                Name = application.Name!,
                Description = application.Description!,
                Outline = application.Outline!,
            };
        }

        public Task<List<ApplicationDto>> GetUsubmittedApplicationOlderDateAsync(DateTime unsubmittedOlder)
        {
            var applications = _applicationRepository.GetUnsubmittedApplicationOlderDate(unsubmittedOlder);
        }
    }
}
