using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace PathfinderAI
{
    public class Path<T> where T : Node
    {
        public List<T> Nodes { get; internal set; }
        public double TotalWeight { get; internal set; }
        public T Start { get; internal set; }
        public T Target { get; internal set; }

        public Path()
        {
            this.Nodes = new List<T>();
            this.TotalWeight = 0;
            this.Start = null;
            this.Target = null;
        }

        public Path(List<T> nodes, double totalWeight)
        {
            this.Nodes = nodes;
            this.TotalWeight = totalWeight;
        }


        public string ToString<R>(Expression<Func<T, R>> expression)
        {
            var result = string.Empty;
            PropertyInfo type;

            if (Nodes.Count > 0)
            {
                var member = (MemberExpression)expression.Body;
                type = typeof(T).GetProperty(member.Member.Name);
            }
            else return "There is no existing path.";

            result += "Start Node: " + type.GetValue(Start).ToString() + "\nTarget Node: " + type.GetValue(Target).ToString() + "\nTotal Distance: " + TotalWeight + "\n";

            for(int i = 0; i < Nodes.Count; i++)
                result += type.GetValue(Nodes[i]).ToString() + (i < Nodes.Count - 1 ? " -> " : "");

            result += "\n\n";

            return result;
        }
    }
}