

using System.ComponentModel;

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
            // creates a new group to put the various sub groups of current group
            //var personGroups = new List<PersonGroup>();
            List<PersonGroup> personsGroups = new List<PersonGroup>();
         
            
            // 1) sort the list of persons
            // persons.Sort()
            persons.Sort();

            // current group = new person group
            // current group you are adding names into
            var currentGroup = new PersonGroup();

            // 2) repeatedly add next person if they are within distance/ otherwise make new group
            // foreach person in persons (for each person in the list of persons)
            // p = person
            foreach (var p in persons)
            {
                // if(current group == empty) add first person
                if (currentGroup.Count == 0)
                {
                    currentGroup.Persons.Add(p);
                    
                }
                // else if distance(person, current group[0]) <= distance
                else if (p.Distance(currentGroup[0]) <= distance)
                {
                    // add person
                    currentGroup.Persons.Add(p);
                }
                // add the current group to List of PersonGroups
                else
                {

                    //if (p.Distance(currentGroup[0]) >= distance)
                    //{

                    //}
                    personsGroups.Add(currentGroup);
                    //return personsGroups;
                    // make new group
                    var newCurrentGroup = new PersonGroup();
                    currentGroup = newCurrentGroup;
                    // add person to new group
                    newCurrentGroup.Persons.Add(p);
                }

            }

            //Console.WriteLine(personsGroups);
            return personsGroups;

        }

    }
}
