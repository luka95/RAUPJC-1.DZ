using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary2
{
    internal class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> genericList;
        private int currentIndex = 0;
        private T currentItem; 

        public GenericListEnumerator(GenericList<T> genericList)
        {
            this.genericList = genericList;
            currentIndex = -1;
            currentItem = default(T);
        }

        public T Current
        {
            get
            {
                return currentItem;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++currentIndex >= genericList.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                currentItem = genericList.GetElement(currentIndex);
            }
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}