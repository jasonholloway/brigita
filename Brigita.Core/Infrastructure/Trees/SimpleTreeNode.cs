using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure.Trees
{
    public class SimpleTreeNode<TValue>
    {
        public static readonly SimpleTreeNode<TValue>[] EmptyArray = new SimpleTreeNode<TValue>[0];


        public TValue Value { get; private set; }

        public SimpleTreeNode<TValue>[] Children { get; private set; }


        public SimpleTreeNode(TValue value, IEnumerable<SimpleTreeNode<TValue>> children = null) {
            Value = value;
            Children = children != null 
                        ? children.ToArray()
                        : EmptyArray;
        }
    }
}
