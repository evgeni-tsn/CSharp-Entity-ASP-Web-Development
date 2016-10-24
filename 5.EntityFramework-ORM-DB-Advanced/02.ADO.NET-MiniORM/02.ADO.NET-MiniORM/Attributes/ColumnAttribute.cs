using System;

namespace _02.ADO.NET_MiniORM.Attributes
{
    class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
    }
}
