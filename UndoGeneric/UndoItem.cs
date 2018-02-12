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
    public class UndoItem<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndoItem{T}"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <param name="value">The value.</param>
        public UndoItem(string date, string time, T value)
        {
            _date = date;
            _time = time;
            _value = value;
            EstimateSize();
        }
        /// <summary>
        /// The date
        /// </summary>
        private string _date;
        /// <summary>
        /// The time
        /// </summary>
        private string _time;
        /// <summary>
        /// The size
        /// </summary>
        private long _size;
        /// <summary>
        /// The value
        /// </summary>
        private T _value;
        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get { return this._date; } }
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time { get { return this._time; } }
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public long Size { get { return _size; } }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get { return this._value; } }

        /// <summary>
        /// Estimates the size.
        /// </summary>
        private void EstimateSize()
        {
            _size = 0;
            long charsize = sizeof(char);
            _size += ((Date.Length + Time.Length) * charsize);
            using (Stream stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, _value);
                _size += stream.Length;
            }

        }


    }
}
