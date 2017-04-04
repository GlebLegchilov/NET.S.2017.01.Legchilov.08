using System;
using System.Globalization;

namespace Task1
{
    public sealed class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        /// <summary>
        /// The class standard constructor.
        /// </summary>
        public Customer() : this(string.Empty, string.Empty, default(decimal))
        {

        }

        /// <summary>
        /// The class constructor with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contactPhone"></param>
        /// <param name="revenue"></param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        #region Methods
        /// <summary>
        /// Formatts customer's data to string presentation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString("G", new CultureInfo("en-US"));
        }

        /// <summary>
        /// Formatts customer's data to string presentation.
        /// </summary>
        /// <param name="format">Presentation format</param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return this.ToString(format, new CultureInfo("en-US"));
        }

        /// <summary>
        /// Formatts customer's data to string presentation.
        /// </summary>
        /// <param name = "format" > Presentation format</param>
        /// <param name = "formatProvider" > Presentation format provider</param>
        /// <returns>String which represent customer instance.</returns>
        public string ToString(string format, IFormatProvider fp)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (fp == null)
                fp = new CultureInfo("en-US");
            if (!(fp is CultureInfo))
                return string.Format(fp, "{0:" + format + "}", this);

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NPR": return string.Format(fp, "{0}, {1}, {2:N}", Name, ContactPhone, Revenue);
                case "NP": return string.Format(fp, "{0}, {1}", Name, ContactPhone);
                case "NR": return string.Format(fp, "{0}, {1:N}", Name, Revenue);
                case "PR": return string.Format(fp, "{0}, {1:N}", ContactPhone, Revenue);
                case "N": return string.Format(fp, "{0}", Name);
                case "P": return string.Format(fp, "{0}", ContactPhone);
                case "R": return string.Format(fp, "{0:N}", Revenue);
                default:
                    throw new FormatException(string.Format($"The {format} format string is not supported."));
            }

        }
#endregion

    }
}
