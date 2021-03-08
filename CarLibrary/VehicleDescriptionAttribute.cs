using System;
using System.Collections.Generic;
using System.Text;

namespace CarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
