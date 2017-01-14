using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels.User
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Login { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
    }
}