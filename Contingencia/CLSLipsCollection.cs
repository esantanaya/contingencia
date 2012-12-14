using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSLipsCollection : Collection<CLSLips>
    {
        #region IList<CLSLips> Members

        public new int IndexOf(CLSLips item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSLips item)
        {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        public new CLSLips this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSLips> Members

        public new void Add(CLSLips item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public new bool Contains(CLSLips item)
        {
            return base.Contains(item);
        }

        public new void CopyTo(CLSLips[] array, int arrayIndex)
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

        public new void Remove(CLSLips item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSLips> Members

        public new IEnumerator<CLSLips> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
