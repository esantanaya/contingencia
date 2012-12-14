using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSFatomCollection : Collection<CLSFatom>
    {
        #region IList<CLSFatom> Members

        public new int IndexOf(CLSFatom item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSFatom item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSFatom this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSFatom> Members

        public new void Add(CLSFatom item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSFatom item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSFatom[] array, int arrayIndex)
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

        public new void Remove(CLSFatom item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSFatom> Members

        public new IEnumerator<CLSFatom> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
