using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineGroceryShop
{
    public partial class CutomList<Imran>
    {
        //field declaration
       private int _count=0;
       private int _capacity=0;
       //Property Declaration
       public int Count{get{return _count;}} 
       public int Capacity{get{return _capacity;}} 
       //Declaring array
       public Imran[] _array=new Imran[4];
       //Default Constructor
       public CutomList()
       {
        _count=0;
        _capacity=4;
        _array=new Imran[_capacity];
       }
       //Pramaeterised Constructor
       public CutomList(int size)
       {
         _count=0;
         _capacity=size;
         _array=new Imran[_capacity];
       }
       //Creating The Indexer
       public Imran this[int position]
       {
        get{return _array[position];}
        set{_array[position]=value;}
       }
       //Create a fuction called Add
       public void Add(Imran data)
       {
        if(_count==_capacity)
        {
            GrowSize();
        }
        _array[_count]=data;
        _count++;
       }
       //Creating Fuction GrowSize
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