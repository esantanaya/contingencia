using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSLoteCollection : Collection<CLSLote>
    {
        #region IList<CLSFolio> Members

        public new int IndexOf(CLSLote item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSLote item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSLote this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSLote> Members

        public new void Add(CLSLote item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSLote item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSLote[] array, int arrayIndex)
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

        public new void Remove(CLSLote item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSLote> Members

        public new IEnumerator<CLSLote> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
