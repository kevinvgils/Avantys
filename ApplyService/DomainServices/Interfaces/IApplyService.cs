﻿using ApplyService.Domain;

namespace ApplyService.DomainServices.Interfaces
{
    public interface IApplyService
    {
        Task<Applicant> CreateApplicantAsync(Applicant applicant);
        Task<Applicant> UpdateApplicantAsync(Guid id, Applicant applicant);
        Task<Applicant> GetApplicantByIdAsync(Guid id);
        Task<List<Applicant>> GetAllApplicantsAsync();

    }
}
