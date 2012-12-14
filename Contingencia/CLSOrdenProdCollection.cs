using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSOrdenProdCollection : Collection<CLSOrdenProd>
    {
        #region IList<CLSOrdenProd> Members

        public new int IndexOf(CLSOrdenProd item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSOrdenProd item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSOrdenProd this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSOrdenProd> Members

        public new void Add(CLSOrdenProd item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSOrdenProd item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSOrdenProd[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        public new int Count
        {
            get { return base.Count; }
        }

        public bool IsReadOnly
        {
            get { return IsReadOnly; }
        }

        public new void Remove(CLSOrdenProd item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSOrdenProd> Members

        public new IEnumerator<CLSOrdenProd> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}