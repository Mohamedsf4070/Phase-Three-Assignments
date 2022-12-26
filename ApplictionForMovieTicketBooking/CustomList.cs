using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplictionForMovieTicketBooking
{
    public partial class CustomList<Imran>
    {
        //declaring field
        private static int _count=0;
        private static int _capacity=0;
        //declaring Property
        public int Count{get{return _count;}}
        public int Capacity{get{return _capacity;}set{_capacity=value;}}
        public Imran[] _array=new Imran[4];
        //Constructing DEFAULT CONSTRUCTOR
        public CustomList()
        {
           _count=0;
           _capacity=4;
           Imran[] _array=new Imran[_capacity]; 
        }
        //paramaterised constructor
         public CustomList(int size)
        {
           _count=0;
           _capacity=size;
           Imran[] _array=new Imran[_capacity]; 
        }
        //Indexer
        public Imran this[int position]
        {
            get
            {
                return _array[position];
            }
            set
            {
               _array[position]=value;
            }
        }
        //fuction Add
        public void Add(Imran data)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=data;
            _count++;
        }
        //GrowSize function
        public void GrowSize()
        {
            _capacity*=2;
            Imran[] temp=new Imran[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
    }
}