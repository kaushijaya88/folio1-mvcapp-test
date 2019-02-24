using System;
using System.Collections.Generic;
using System.Text;
using static StudentManagementSystem.DTO.UtilityEnumDto;

namespace StudentManagementSystem.DTO
{
    public class ResponseDto
    {
        public ResponseCode ResponseCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
