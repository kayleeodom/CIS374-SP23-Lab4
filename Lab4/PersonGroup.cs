

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // Done
        public char? EndingLetter { 
            get
            {
                // if Persons is SORTED
                return Persons[Count - 1].FirstName[Count - 1];
            }
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
           var personGroups = new List<PersonGroup>();
            

            // 1) sort the list of persons
            // persons.Sort()
            personGroups.Sort();

            // current group = new person group
            var currentGroup = new PersonGroup();

            // 2) repeatedly add next person if they are within distance/ otherwise make new group
            // foreach person in persons
            foreach (var p in persons)
            {
                // if(current group == empty) add first person
                if (currentGroup.Count == 0)
                {
                    currentGroup.Persons.Add(p);
                }
                // else if distance(person, current group[0]) <= distance
                else if (p.Distance(p) <= distance)
                {
                    // add person
                    currentGroup.Persons.Add(p);
                }
                // else
                else
                {
                    // add the current group to List of PersonGroups
                    personGroups.Add(currentGroup);
                }
            }

            Console.WriteLine(personGroups);
            return personGroups;


            // make new group
            // add person to new group

        }

    }
}
