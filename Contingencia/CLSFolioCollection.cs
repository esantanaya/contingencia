using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSFolioCollection : Collection<CLSFolio>
    {
        #region IList<CLSFolio> Members

        public new int IndexOf(CLSFolio item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSFolio item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSFolio this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSFolio> Members

        public new void Add(CLSFolio item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSFolio item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSFolio[] array, int arrayIndex)
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

        public new void Remove(CLSFolio item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSFolio> Members

        public new IEnumerator<CLSFolio> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
