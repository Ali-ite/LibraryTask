﻿using Abp.Application.Services.Dto;

namespace LibraryTask.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

