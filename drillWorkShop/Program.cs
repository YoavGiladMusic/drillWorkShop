using System.Collections.Generic;
using System.Diagnostics;

namespace drillWorkShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProgram runProgram = new();
            runProgram.Run();
        }

        class RunProgram
        {
            public void Run()
            {
                List<Person> personDataBase = new();
                personDataBase.Add(new Person { Name = "rami", Age = 35, Id = 1234 });
                personDataBase[0].Character.AddRange(new string[] { "nice", "brave" });
                personDataBase[0].Hobbies.Add("skating", 3);
                personDataBase[0].Hobbies.Add("bowling", 2);
                personDataBase.Add(new Person { Name = "rita", Age = 40, Id = 125834 });
                personDataBase[1].Character.AddRange(new string[] { "charming", "talented" });
                personDataBase[1].Hobbies.Add("singing", 10);
                personDataBase[1].Hobbies.Add("dancing", 5);
                string[] validInput = { "1", "2", "3", "4" };
                Console.WriteLine("Welcome to the Database");
                while (true)
                {
                    Console.WriteLine("\nPlease enter the number of your desirable operation:\n1.ADD\n2.ERASE\n3.SEARCH\n4.PRINT all");
                    string input = Console.ReadLine().Trim();
                    if (validInput.Contains(input))
                    {
                        SwitchOperations(input, personDataBase);
                    }
                    else
                    {
                        Console.WriteLine("Invalid string");
                    }
                }
            }
            public void SwitchOperations(string input, List<Person> personDataBase)
            {
                switch (input[0])
                {
                    case '1':
                        addPerson(personDataBase);
                        break;
                    case '2':
                        erasePerson(personDataBase);
                        break;
                    case '3':
                        searchPerson(personDataBase);
                        break;
                    case '4':
                        printAll(personDataBase);
                        break;

                }
            }
            public void addPerson(List<Person> personDataBase)
            {
                int i = personDataBase.Count();
                Console.WriteLine("Add person's name and hit ENTER");
                personDataBase.Add(new Person { Name = Console.ReadLine().Trim() });
                Console.WriteLine("Add person's age and hit ENTER");
                personDataBase[i].Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Add person's Id and hit ENTER");
                personDataBase[i].Id = int.Parse(Console.ReadLine());
                getCharcteristic(personDataBase, i);
                getHobbies(personDataBase, i);
            }
            public void getCharcteristic(List<Person> personDataBase, int i)
            {
                Console.WriteLine("Add person's Charateristic");
                string[] charateristic = Console.ReadLine().Split(" ");
                foreach (var character in charateristic)
                {
                    {
                        personDataBase[i].Character.Add(character);
                    }
                }
            }

            public void getHobbies(List<Person> personDataBase, int i)
            {
                string userInput = "";
                while (userInput != "0")
                {
                    Console.WriteLine("Add person's hobbie and hit ENTER or press 0 to stop");
                    userInput = Console.ReadLine().Trim();
                    if (userInput != "0")
                    {
                        Console.WriteLine($"how much time (in houres) {personDataBase[i].Name} spends on {userInput} in a week?");
                        int time = int.Parse(Console.ReadLine().Trim());
                        personDataBase[i].Hobbies.Add(userInput, time);
                    }
                }
            }

            public void erasePerson(List<Person> personDataBase)
            {
                Console.WriteLine("Enter the name of the person you would like to delete");
                string deleteName = Console.ReadLine().Trim();
                bool found=false;
                for (int i = 0; i < personDataBase.Count; i++)
                {
                    if (personDataBase[i].Name == deleteName)
                    {
                        personDataBase.RemoveAt(i);
                        Console.WriteLine("This person has been removed.");
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Person not founded");
                }
            }

            public void searchPerson(List<Person> personDataBase)
            {
                string[] validInput = { "1", "2", "3", "4", "5" };
                bool validSearch = false;
                while (!validSearch)
                {
                    Console.WriteLine("Enter the number of the relevant search:\n1.Search by NAME\n2.Search by AGE\n3.Search by Id\n4.Search by CHARACTER\n5.Search by HOBBIE");
                    string input = Console.ReadLine().Trim();
                    if (validInput.Contains(input))
                    {
                        searchSwitch(input, personDataBase);
                        validSearch = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                    }
                }
            }

            public void searchSwitch(string input, List<Person> personDataBase)
            {
                switch (input[0])
                {
                    case '1':
                        findByName(personDataBase);
                        break;
                    case '2':
                        findByAge(personDataBase);
                        break;
                    case '3':
                        findById(personDataBase);
                        break;
                    case '4':
                        findByCharacter(personDataBase);
                        break;
                    case '5':
                        findByHobbie(personDataBase);
                        break;
                }
            }

            public void findByName(List<Person> personDataBase)
            {
                bool isSearching = true;

                while (isSearching)
                {
                    Console.WriteLine($"Enter the person's name you whish to search or press 0 to return start menu");
                    string searchName = Console.ReadLine().Trim();
                    if (searchName == "0")
                    {
                        isSearching = false;
                    }
                    else if
                    (personDataBase.Exists(pe => pe.Name == searchName))
                    {
                        Console.WriteLine("found him!");
                        Console.WriteLine(personDataBase.Find(per => per.Name == searchName).ToString());
                    }
                    else
                    {
                        Console.WriteLine("no matches found");
                    }
                }
            }

            public void findByAge(List<Person> personDataBase)
            {
                bool isSearching = true;

                while (isSearching)
                {
                    Console.WriteLine($"Enter the person's age you whish to search or press 0 to return start menu");
                    int searchAge = int.Parse(Console.ReadLine().Trim());
                    if (searchAge == 0)
                    {
                        isSearching = false;
                    }
                    else if
                    (personDataBase.Exists(pe => pe.Age == searchAge))
                    {
                        Console.WriteLine("found person!");
                        Console.WriteLine(personDataBase.Find(per => per.Age == searchAge).ToString());
                    }
                    else
                    {
                        Console.WriteLine("no matches found");
                    }
                }
            }

            public void findById(List<Person> personDataBase)
            {
                bool isSearching = true;

                while (isSearching)
                {
                    Console.WriteLine($"Enter the person's Id number you whish to search or press 0 to return start menu");
                    int searchId = int.Parse(Console.ReadLine().Trim());
                    if (searchId == 0)
                    {
                        isSearching = false;
                    }
                    else if
                    (personDataBase.Exists(pe => pe.Id == searchId))
                    {
                        Console.WriteLine("found person!");
                        Console.WriteLine(personDataBase.Find(per => per.Id == searchId).ToString());
                    }
                    else
                    {
                        Console.WriteLine("no matches found");
                    }
                }
            }

            public void findByCharacter(List<Person> personDataBase)
            {
                bool isSearching = true;
                bool found = false;

                while (isSearching)
                {
                    Console.WriteLine($"Enter the person's Character you whish to search or press 0 to return the start menu");
                    string searchCharacter = (Console.ReadLine().Trim());
                    if (searchCharacter == "0")
                    {
                        isSearching = false;
                    }
                    else
                        for (int i = 0; i < personDataBase.Count; i++)
                        {
                            if (personDataBase[i].Character.Exists(pe => pe == searchCharacter))
                            {
                                {
                                    Console.WriteLine(personDataBase[i].ToString());
                                    isSearching = false;
                                    found = true;
                                }
                            }

                        }
                    if (!found)
                    {
                        Console.WriteLine("no matches found");
                    }
                }
            }
            public void findByHobbie(List<Person> personDataBase)
            {
                bool isSearching = true;
                bool found = false;

                while (isSearching)
                {
                    Console.WriteLine($"Enter the person's hobbie you whish to search or press 0 to return the start menu");
                    string searchHobbie = (Console.ReadLine().Trim());
                    if (searchHobbie == "0")
                    {
                        isSearching = false;
                    }
                    else
                        for (int i = 0; i < personDataBase.Count; i++)
                        {
                            if (personDataBase[i].Hobbies.ContainsKey(searchHobbie))
                            {
                                {
                                    Console.WriteLine(personDataBase[i].ToString());
                                    isSearching = false;
                                    found = true;
                                }
                            }

                        }
                    if (!found)
                    {
                        Console.WriteLine("no matches found");
                    }
                }
            }
            public void printAll(List<Person> personDataBase)
            {
                if (personDataBase.Count > 0)
                {
                    Console.WriteLine("Those are the persons on the Database:");
                    foreach (Person person in personDataBase)
                    {
                        Console.WriteLine(person.ToString());
                    }
                }
            }
        }


    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

        public List<string> Character = new();

        public Dictionary<string, int> Hobbies = new();

        private string HobbiesToString()
        {
            {
                if (this.Hobbies.Count == 0)
                    return "";
                    
                string result = "Hobbies are: ";
                foreach (var hobbie in this.Hobbies)
                {
                    result += $"spending {hobbie.Value} hours a week on {hobbie.Key}, ";
                }
                result = result.Remove(result.Length - 2,2);
                result += ".";
                return result;
            }
        }

        private string CharacterToString()
        {
            {
                if (this.Character.Count==0)
                    return "";

                string result = "Character traits are:";
                foreach (var character in this.Character)
                {
                    result += $"{character},";
                }
                result = result.Remove(result.Length - 1, 1);
                return result;
            }
        }

        public override string ToString()
        {
            return $"name:{Name}, age:{Age}, id:{Id}\n{HobbiesToString()} \n{CharacterToString()}.\n ";
        }
    }

}