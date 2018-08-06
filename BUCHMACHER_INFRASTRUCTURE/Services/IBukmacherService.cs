using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    public interface IBukmacherService
    {
        void Register(string name);
        BukmacherDTO Get(string email);
    }
}
