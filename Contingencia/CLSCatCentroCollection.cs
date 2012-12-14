using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class CLSCatCentroCollection : Collection<CLSCatCentro>
    {
        #region IList<CLSCatCentro> Members

        public new int IndexOf(CLSCatCentro item) {
            return base.IndexOf(item);
        }

        public new void Insert(int index, CLSCatCentro item) {
            base.Insert(index, item);
        }

        public new void RemoveAt(int index) {
            base.RemoveAt(index);
        }

        public new CLSCatCentro this[int index] {
            get { return base[index]; }
            set { base[index] = value; }
        }
        #endregion

        #region ICollection<CLSCatCentro> Members

        public new void Add(CLSCatCentro item) {
            base.Add(item);
        }

        public new void Clear() {
            base.Clear();
        }

        public new bool Contains(CLSCatCentro item) {
            return base.Contains(item);
        }

        public new void CopyTo(CLSCatCentro[] array, int arrayIndex) { 
            base.CopyTo(array, arrayIndex);
        }

        public new int Count{
            get { return base.Count; }
        }

        public bool IsReadOnly {
            get { return IsReadOnly; }
        }

        public new void Remove(CLSCatCentro item) {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<CLSCatCentro> Members

        public new IEnumerator<CLSCatCentro> GetEnumerator() {
            return base.GetEnumerator();
        }

        #endregion
    }
}
