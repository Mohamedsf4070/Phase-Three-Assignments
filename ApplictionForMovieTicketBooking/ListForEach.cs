using System;

using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace ApplictionForMovieTicketBooking
{
    public partial class CustomList<Imran>:IEnumerable,IEnumerator
    {
     int i;  
     public IEnumerator GetEnumerator()
     {
        i=-1;
        return (IEnumerator)this;
     } 
     public bool MoveNext()
     {
        if(i<_count-1)
        {
            ++i;
            return true;
        }
        Reset();
        return false;
     }
     public object Current
     {
       get
       {
           return _array[i];
       }
     }
     public void Reset()
     {
        i=-1;
     }
    }
}