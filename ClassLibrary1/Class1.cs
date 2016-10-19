using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(int item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </ summary >
        int GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);
        /// <summary >
        /// Readonly property . Gets the number of items contained in the collection.
        /// </ summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(int item);
    }


    public class IntegerList : IIntegerList
    {
        private int _initialSize;
        private int _count = 0;
        private int[] _internalStorage; 
        

        public IntegerList()
        {
            _initialSize = 4;
            _internalStorage = new int [_initialSize];
        }
        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                _initialSize = 4;
            }
            else
            {
                _initialSize = initialSize;                
            }
            _internalStorage = new int[_initialSize];
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(int item)
        {
            if (_count >= _initialSize)
            {
                _initialSize *= 2;
                Array.Resize(ref _internalStorage, _initialSize);
            }             
            _internalStorage[_count] = item;
            _count++;

        }

        public void Clear()
        {
            _count = 0;
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
        }

        public bool Contains(int item)
        {
            foreach(int value in _internalStorage)
            {
                if (value == item) return true;
            }
            return false;

        }

        public int GetElement(int index)
        {
            if(index < _internalStorage.Length && index >= 0)
            {
                return _internalStorage.ElementAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            return Array.IndexOf(_internalStorage, item);
        }

        public bool Remove(int item)
        {
            int index = Array.IndexOf(_internalStorage, item);
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index<0 || index >= _count)
            {
                return false;
            }
            _internalStorage[_count] = 0;
            _count--;
            for (int i = index; i <= _count; i++)
            {
               _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
    }
}
