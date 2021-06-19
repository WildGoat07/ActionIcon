using System;
using System.Collections.Generic;
using System.Text;

namespace ActionIcon
{
    public class IconChangedEventArgs : ValueChangedEventArgs<Icon?>
    {
        public IconChangedEventArgs(Icon? oldValue, Icon? newValue) : base(oldValue, newValue)
        {
        }
    }
}