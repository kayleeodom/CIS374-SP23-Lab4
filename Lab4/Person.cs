using System.Diagnostics.CodeAnalysis;

namespace Lab4
{
    public class Person: IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, string lastName, DateTime birthday):this(firstName, lastName)
        {
            Birthday = birthday;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if( other == null)
            {
                throw new NullReferenceException("Other Person must not be null");
            }

            return this.FirstName.CompareTo(other.FirstName);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


        // TODO
        /// <summary>
        /// Computes the alphabetic distance between this person and the given pereson
        /// </summary>
        /// <param name="other">The other person</param>
        /// <returns>The distance (case insensitively) between this person and the given person.
        /// Note that this distance is always positive. 
        /// </returns>
        public int Distance(Person other)
        {

            

            // check that other isn't null
            if (other == null)
            {
                throw new NullReferenceException("Other Person must not be null");
            }
            //return difference;


            // compute distance between first letters of first name

            //char c = 'a';   // this person
            //char d = 'z';   // given person

            //char c = (char)other.FirstName[1];
            char c = other.FirstName[0];
            //char d = (char)this.FirstName[1];
            char d = this.FirstName[1];

            // find difference and has to be always positive
            int difference = Math.Abs((char.ToLower(c) - char.ToLower(d)));
            //int difference = Math.Abs(c - d);

            Console.WriteLine( difference );
            return difference;
        }


    }
}
