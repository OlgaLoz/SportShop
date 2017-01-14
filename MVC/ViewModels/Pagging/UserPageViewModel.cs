using System.Collections.Generic;
using MVC.ViewModels.User;

namespace MVC.ViewModels.Pagging
{
    public class UserPageViewModel
    {
        public string SearchName { get; set; }
        public List<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}