using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSTraspCalidadCollection : Collection<CLSTraspCalidad>
    {
        #region IList<CLSFolio> Members

        public new int IndexOf(CLSTraspCalidad item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSTraspCalidad item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSTraspCalidad this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSTraspCalidad> Members

        public new void Add(CLSTraspCalidad item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSTraspCalidad item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSTraspCalidad[] array, int arrayIndex)
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

        public new void Remove(CLSTraspCalidad item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSTraspCalidad> Members

        public new IEnumerator<CLSTraspCalidad> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
