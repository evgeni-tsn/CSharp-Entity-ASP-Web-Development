using System;

namespace _02.ADO.NET_MiniORM.Attributes
{
    class EntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}
