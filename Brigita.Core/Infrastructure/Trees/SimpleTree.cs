using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure.Trees
{
    public class SimpleTree<TValue>
    {
        public SimpleTreeNode<TValue>[] Roots { get; private set; }

        public SimpleTree(IEnumerable<SimpleTreeNode<TValue>> roots = null) {
            Roots = roots != null   
                    ? roots.ToArray()
                    : SimpleTreeNode<TValue>.EmptyArray;
        }
    }




    public static class SimpleTree
    {
        public static SimpleTree<TItem> BuildFromIndexedItems<TItem, TIndex>(
                                                        IEnumerable<TItem> items,
                                                        Func<TItem,TIndex> fnGetIndex,
                                                        Func<TItem,TIndex> fnGetParentIndex
                                                        ) 
        {
            var rItems = items.ToArray();

            var dTempNodes = rItems
                                .Select(i => new TempNode<TItem>(i))
                                .ToDictionary(n => fnGetIndex(n.Item));


            foreach(var t in dTempNodes.Values
                                    .Select(n => new { ParentID = fnGetParentIndex(n.Item), Node = n })) 
            {
                if(object.Equals(t.ParentID, default(TIndex))) {
                    continue;
                }
                
                TempNode<TItem> parent = null;

                if(!dTempNodes.TryGetValue(t.ParentID, out parent)) {
                    throw new InvalidOperationException("Category with bad parent id encountered!");
                }

                t.Node.Parent = parent;
                parent.Children.Add(t.Node);
            }

            //now recursively pass into SimpleTree structure

            var rootTempNodes = dTempNodes.Values
                                    .Where(n => n.Parent == null);

            var rootTreeNodes = rootTempNodes
                                    .Select(n => n.Convert2TreeNode());

            return new SimpleTree<TItem>(rootTreeNodes.ToArray());
        }


        class TempNode<TItem>
        {
            public TItem Item { get; private set; }
            public TempNode<TItem> Parent { get; set; }
            public List<TempNode<TItem>> Children { get; private set; }

            public TempNode(TItem item) {
                Item = item;
                Children = new List<TempNode<TItem>>();
            }

            public SimpleTreeNode<TItem> Convert2TreeNode() {
                return new SimpleTreeNode<TItem>(
                                Item,
                                Children.Select(n => n.Convert2TreeNode())
                                            .ToArray()
                                );
            }
        }
    }



}
