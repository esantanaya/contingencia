using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSCatDestinoCollection : Collection<CLSCatDestino>
    {
        #region IList<CLSCatDestino> Members

        public new int IndexOf(CLSCatDestino item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSCatDestino item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSCatDestino this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSCatDestino> Members

        public new void Add(CLSCatDestino item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSCatDestino item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSCatDestino[] array, int arrayIndex)
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

        public new void Remove(CLSCatDestino item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSCatDestino> Members

        public new IEnumerator<CLSCatDestino> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
