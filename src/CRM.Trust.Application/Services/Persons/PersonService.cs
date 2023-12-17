﻿using AutoMapper;
using CRM.Trust.Application.Data;
using CRM.Trust.Application.Services.Persons.Models;
using CRM.Trust.Domain.Core;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Application.Services.Persons;

public interface IPersonService
{
    Task<Result> LoadPersonsList(List<UploadPersonModel> personList, CancellationToken cancellationToken);
    Task<Result<List<PersonDetailsModel>>> GetPersonsList(CancellationToken cancellationToken);
}

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly ICoreContext _coreContext;

    public PersonService(ICoreContext coreContext, IMapper mapper)
    {
        _coreContext = coreContext;
        _mapper = mapper;
    }

    public async Task<Result> LoadPersonsList(List<UploadPersonModel> personList, CancellationToken cancellationToken)
    {
        foreach (var personModel in personList)
        {
            var personId = Guid.NewGuid();
            var person = _mapper.Map<Person>(personModel);
            
            person.Id = personId;
            await _coreContext.Persons.AddAsync(person, cancellationToken);
            
            if (personModel.ActualJob is not null)
            {
                var job = _mapper.Map<PersonJob>(personModel.ActualJob);
                job.PersonId = personId;
                await _coreContext.PersonJobs.AddAsync(job, cancellationToken);
            }
            if (personModel.Passport is not null)
            {
                var passport = _mapper.Map<PersonPassport>(personModel.Passport);
                passport.PersonId = personId;
                await _coreContext.PersonPassports.AddAsync(passport, cancellationToken);
            }

            await _coreContext.SaveChangesAsync(cancellationToken);
        }
        return Result.Ok();
    }
    
    public async Task<Result<List<PersonDetailsModel>>> GetPersonsList(CancellationToken cancellationToken)
    {
        var persons = await _coreContext.Persons
            .AsNoTracking()
            .Include(e => e.Jobs)
            .Include(e => e.Contacts)
            .Include(e => e.Passports)
            .Include(e => e.Loans)
            .ToListAsync(cancellationToken);

        var personModels = new List<PersonDetailsModel>();
        foreach (var person in persons)
        {
            var personModel = _mapper.Map<PersonDetailsModel>(person);
            if (person.Jobs.Any(e => e.EndDate != null))
            {
                var job = person.Jobs
                    .First(e => e.EndDate != null);
                personModel.ActualJob = _mapper.Map<PersonJobModel>(job);
            }
            if (person.Passports.Any())
            {
                var passport = person.Passports.First();
                personModel.Passport = _mapper.Map<PersonPassportModel>(passport);
            }
            personModels.Add(personModel);
        }
        return Result.Ok(personModels);
    }
}