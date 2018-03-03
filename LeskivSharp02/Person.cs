using System;

namespace LeskivSharp02
{
    public class Person
    {
        internal string Name { get; }
        internal string Surname { get; }
        internal string Email { get; }
        internal DateTime Birthday { get; }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public bool IsAdult => DateTime.Today.YearsPassedCnt(Birthday) >= 18;
        public bool IsBirthday => DateTime.Today.DayOfYear == Birthday.DayOfYear;

        public string ChineseSign => ChineseZodiaсs[(Birthday.Year + 8) % 12];        
        public string SunSign
        {
            get
            {
                var day = Birthday.Day;
                int westZodiacNum;
                switch (Birthday.Month)
                {
                    case 1:  //January
                        westZodiacNum = day <= 20 ? 9 : 10;
                        break;
                    case 2: //February
                        westZodiacNum = day <= 19 ? 10 : 11;
                        break;
                    case 3: //March
                        westZodiacNum = day <= 20 ? 11 : 0;
                        break;
                    case 4: //April
                        westZodiacNum = day <= 20 ? 0 : 1;
                        break;
                    case 5: //May
                        westZodiacNum = day <= 20 ? 1 : 2;
                        break;
                    case 6: //June
                        westZodiacNum = day <= 20 ? 2 : 3;
                        break;
                    case 7: //Jule
                        westZodiacNum = day <= 21 ? 3 : 4;
                        break;
                    case 8: //August
                        westZodiacNum = day <= 22 ? 4 : 5;
                        break;
                    case 9: //September
                        westZodiacNum = day <= 21 ? 5 : 6;
                        break;
                    case 10: //October
                        westZodiacNum = day <= 21 ? 6 : 7;
                        break;
                    case 11: //November
                        westZodiacNum = day <= 21 ? 7 : 8;
                        break;
                    case 12: //December
                        westZodiacNum = day <= 21 ? 8 : 9;
                        break;
                    default:
                        westZodiacNum = 0;
                        break;
                }
                return WesternZodiaсs[westZodiacNum];
            }
        }

        private static readonly string[] WesternZodiaсs = {
            "Ram",
            "Bull",
            "Twins",
            "Crab",
            "Lion",
            "Virgin",
            "Scales",
            "Scorpion",
            "Archer",
            "Mountain Sea-Goat",
            "Water Bearer",
            "Fish"
        };

        private static readonly string[] ChineseZodiaсs = {
            "Rat",
            "Ox",
            "Tiger",
            "Rabbit",
            "Dragon",
            "Snake",
            "Horse",
            "Goat",
            "Monkey",
            "Rooster",
            "Dog",
            "Pig"
        };
    }
}