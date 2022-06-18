﻿using NLayered.Contracts.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayered.Contracts.Services
{
    public interface IDokumentiService
    {
        Task<List<DokumentDto>> GetAll(bool trackChanges);

        Task<DokumentDto> Get(int dokumentId, bool trackChanges);

        Task Create(DokumentDto dokumentDto);

        Task Delete(int dokumentId);
    }
}
