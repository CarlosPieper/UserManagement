using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Application._Common;
using UserManagement.Application.Services.Models.Dto;

namespace UserManagement.Application.Services.Models.Response.Person
{
    public class GetAllResponse : BaseResponse
    {
        public List<PersonDto> People { get; set; }
    }
}
