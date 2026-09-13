using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using Refit;
using AqaTest.DTO.PetsDataDTO;

namespace Interfaces

{
    public interface IPetsApi
    
    {
        [Get("/pets")]
        Task<AllPetsResponseDTO> GetAllPetsAsync();

        [Get("/pets/{id}")]
        Task<PetsDTO> GetPetByIdAsync(string id);

        [Get("/pets")]
        Task<AllPetsResponseDTO> GetAllPetsByFilterAgeMinAndLimitAsync([Query] int ageMin, [Query] int limit);
    }
}