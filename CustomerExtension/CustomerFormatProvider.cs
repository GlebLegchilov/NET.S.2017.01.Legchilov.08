using System;
using System.Globalization;
using Task1;

namespace Task1Extension
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider _parent;

        public CustomerFormatProvider() : this(new CultureInfo("en-US"))
        {

        }

        public CustomerFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || !(arg is Customer) || string.IsNullOrEmpty(format))
                return string.Format(_parent, "{0:" + format + "}", arg);

            Customer c = (Customer)arg;

            switch (format.ToUpperInvariant())
            {
                case "NPRD": return string.Format(formatProvider, "Customer record: {0}, {1}, {2:c}", c.Name, c.ContactPhone, c.Revenue);
                case "NRD": return string.Format(formatProvider, "Customer record: {0}, {1:c}", c.Name, c.Revenue);
                case "RD": return string.Format(formatProvider, "Customer record: {0:c}", c.Revenue);
                default: return string.Format(_parent, "{0:" + format + "}", arg);
            }
        }
    }
}
