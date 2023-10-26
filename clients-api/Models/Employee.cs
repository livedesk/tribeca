using clients_api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;

namespace clients_api.Models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DevMagicBio => ConvertToDevMagic();
        public string StarSign => GetStarSign();

        public string ConvertToDevMagic()
        {
            string[] words = Bio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string devMagicSentence = "";

            foreach (string word in words)
            {
                devMagicSentence += word.ConvertToDevMagic() + " ";
            }

            return devMagicSentence;
        }

     
        public string GetStarSign()
        {
            int day = DateOfBirth.Day;
            int month = DateOfBirth.Month;

            switch (month)
            {
                case 1:
                    return (day <= 19) ? "Capricorn" : "Aquarius";
                case 2:
                    return (day <= 18) ? "Aquarius" : "Pisces";
                case 3:
                    return (day <= 20) ? "Pisces" : "Aries";
                case 4:
                    return (day <= 19) ? "Aries" : "Taurus";
                case 5:
                    return (day <= 20) ? "Taurus" : "Gemini";
                case 6:
                    return (day <= 20) ? "Gemini" : "Cancer";
                case 7:
                    return (day <= 22) ? "Cancer" : "Leo";
                case 8:
                    return (day <= 22) ? "Leo" : "Virgo";
                case 9:
                    return (day <= 22) ? "Virgo" : "Libra";
                case 10:
                    return (day <= 22) ? "Libra" : "Scorpio";
                case 11:
                    return (day <= 21) ? "Scorpio" : "Sagittarius";
                case 12:
                    return (day <= 21) ? "Sagittarius" : "Capricorn";
                default:
                    return "Unknown";
            }
        }
    }
}
