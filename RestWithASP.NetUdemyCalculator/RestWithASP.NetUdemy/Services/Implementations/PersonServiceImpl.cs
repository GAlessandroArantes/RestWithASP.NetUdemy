using RestWithASP.NetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP.NetUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> listaPessoas = new List<Person>();

            for( int i = 0; i < 8; i++  )
            {
                Person person = MockPerson(i);
                listaPessoas.Add(person);
            }
            return listaPessoas;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndSet(),
                FirstName = "Guilherme" + i,
                LastName = "Arantes" + i,
                Address = "Almirante Gonçalves" + i,
                Gender = "Male" + i
            };
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                Id = id,
                FirstName = "Guilherme" + id,
                LastName = "Arantes" + id,
                Address = "Almirante Gonçalves" + id,
                Gender = "Male" + id
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private long IncrementAndSet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
