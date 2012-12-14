using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSCanalFinCollection : Collection<CLSCanalFin>
    {
        #region IList<CLSFolio> Members

        public new int IndexOf(CLSCanalFin item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSCanalFin item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSCanalFin this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSCanalFin> Members

        public new void Add(CLSCanalFin item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSCanalFin item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSCanalFin[] array, int arrayIndex)
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

        public new void Remove(CLSCanalFin item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSCanalFin> Members

        public new IEnumerator<CLSCanalFin> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
