using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace UndoGeneric
{


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Undo<T>
    {
        /// <summary>
        /// The megabyte
        /// </summary>
        const long MEGABYTE = 1048576;
        /// <summary>
        /// The history
        /// </summary>
        private List<UndoItem<T>> history;

        /// <summary>
        /// The check length
        /// </summary>
        private bool checkLength = false;

        /// <summary>
        /// The check size
        /// </summary>
        private bool checkSize = false;

        /// <summary>
        /// The maximum length
        /// </summary>
        private long maxLength;

        /// <summary>
        /// The maximum mb
        /// </summary>
        private int maxMB;

        /// <summary>
        /// The current size
        /// </summary>
        private long currentSize;

        /// <summary>
        /// The cursor
        /// </summary>
        private int cursor = 0;

        /// <summary>
        /// Gets the cursor.
        /// </summary>
        /// <value>
        /// The cursor.
        /// </value>
        public int Cursor { get { return cursor; } }

        /// <summary>
        /// Ups this instance.
        /// </summary>
        public void Up()
        {
            if (cursor < history.Count - 1)
            {
                cursor++;
            }
            else
            {
                cursor = 0;
            }

        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public void Down()
        {
            if (cursor > 0)
            {
                cursor--;
            }
            else
            {
                cursor = history.Count - 1;
            }

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Undo{T}"/> class.
        /// </summary>
        public Undo()
        {
            history = new List<UndoItem<T>>();
            maxLength = 1000;
            maxMB = 1024;
            currentSize = 0;

        }
        /// <summary>
        /// Removes the last item.
        /// </summary>
        /// <returns></returns>
        private bool RemoveLastItem()
        {
            if (history.Count > 0)
            {
                long removeSize = history[0].Size;
                history.RemoveAt(0);
                currentSize = currentSize > removeSize ? currentSize - removeSize : 0;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool AddItem(T item)
        {
            
            long maxBytes = maxMB * MEGABYTE;
            UndoItem<T> undo = new UndoItem<T>(item);
            long targetSize = undo.Size + currentSize; ;
            if (checkSize)
            {
                if (maxBytes < targetSize)
                {
                    while (maxBytes < targetSize)
                    {
                        RemoveLastItem();
                        targetSize = undo.Size + currentSize;
                    }
                }
            }

            if (checkLength)
            {
                if (history.Count >= maxLength)
                {
                    while (history.Count >= maxLength)
                    {

                        RemoveLastItem();

                    }
                }
            }

            currentSize += undo.Size;

            history.Add(undo);
            cursor = history.Count - 1;
            return true;
        }

        /// <summary>
        /// Sets the index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public bool SetIndex(int index)
        {

            if (history.Count - 1 >= index)
            {

                cursor = index;

                return true;

            }
            return false;
        }



        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public UndoItem<T> Current { get { return history[cursor]; } }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns></returns>
        public long GetSize() { return currentSize; }
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public long MaxLength { get { return maxLength; } set { maxLength = (value > 0) ? value : 1; } }
        /// <summary>
        /// Gets or sets the maximum mb.
        /// </summary>
        /// <value>
        /// The maximum mb.
        /// </value>
        public int MaxMB { get { return maxMB; } set { maxMB = (value > 0) ? value : 1; } }

    }

    
}

