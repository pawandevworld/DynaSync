using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPulse.DTOs;

    public class MemberDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Knownas { get; set; }

        public List<JobDto>? Jobs { get; set; }
    }
