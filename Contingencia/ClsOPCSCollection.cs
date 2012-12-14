﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Contingencia
{
    class ClsOPCSCollection: Collection<ClsOPCS>
    {
        #region IList<ClsOPCS> Members

        /// <summary>
        /// gets the index of passed item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new int IndexOf(ClsOPCS item)
        {
            return base.IndexOf(item);
        }

        public new void Insert(int index, ClsOPCS item)
        {
            base.Insert(index, item);
        }

        /// <summary>
        /// removes the item from the collection
        /// </summary>
        /// <param name="index"></param>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        /// <summary>
        /// gets the item at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new ClsOPCS this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
            }
        }

        #endregion

        #region ICollection<ClsOPCS> Members

        /// <summary>
        /// adds the item to the collection
        /// </summary>
        /// <param name="item"></param>
        public new void Add(ClsOPCS item)
        {
            base.Add(item);
        }

        public new void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// Checks whether the item exists or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Contains(ClsOPCS item)
        {
            return base.Contains(item);
        }

        /// <summary>
        /// Copies the Collection to the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public new void CopyTo(ClsOPCS[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the Item Count in the collection
        /// </summary>
        public new int Count
        {
            get
            {
                return base.Count;
            }
        }

        /// <summary>
        /// Gets and Sets whether it's a readonly or not
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return IsReadOnly;
            }
        }

        /// <summary>
        /// Remove the item from the Collectionm
        /// </summary>
        /// <param name="item">Item to be removed from the collection</param>
        public new void Remove(ClsOPCS item)
        {
            base.Remove(item);
        }

        #endregion

        #region IEnumerable<ClsMARA> Members

        /// <summary>
        /// Gets the Enumerator
        /// </summary>
        /// <returns></returns>
        public new IEnumerator<ClsOPCS> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
