
using System;

namespace CinemaApp.data.EntityS
{
    
    public static class CurrentUser
    {
        public static int IdUser { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Patronymic { get; set; }
        public static string PhoneNumber { get; set; }
        public static System.DateTime? DateOfBirth { get; set; }
        public static string Mail { get; set; }

    }
}