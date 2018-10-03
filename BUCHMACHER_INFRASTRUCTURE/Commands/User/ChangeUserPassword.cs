using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Commands.User
{
    public class ChangeUserPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
