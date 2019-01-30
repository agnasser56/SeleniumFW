using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumFramework
{
    public class Command : IEquatable<Command>
    {
        public string ColumnName { get; set; }

        public string CommandName { get; set; }

        public string CommandData { get; set; }

        public bool CommandResult { get; set; }

        public string ErrorDetails { get; set; }

        public string StepImagePath { get; set; }

        public override string ToString()
        {
            return "CommandName: " + CommandName + "   CommandData: " + CommandData;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Command objAsPart = obj as Command;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return CommandName.GetHashCode() + CommandData.GetHashCode();
        }

        public bool Equals(Command other)
        {
            if (other == null) return false;
            return (this.CommandName.Equals(other.CommandName) & this.CommandData.Equals(other.CommandData));
        }

       


    }
}
