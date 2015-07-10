using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure.Trees
{
    public static class SimpleTreeExtensions
    {
        public static void ForEach<TValue>(
                                this SimpleTree<TValue> @this, Action<TValue> fnAction) 
        {
            foreach(var rootNode in @this.Roots) {
                ForEach(rootNode, fnAction);
            }
        }

        public static void ForEach<TValue>(
                                this SimpleTreeNode<TValue> @this, 
                                Action<TValue> fnAction) 
        {
            fnAction(@this.Value);

            foreach(var childNode in @this.Children) {
                ForEach(childNode, fnAction);
            }
        }




        public static void ForEach<TValue>(
                                this SimpleTree<TValue> @this,
                                Action<SimpleTreeNode<TValue>, IEnumerable<SimpleTreeNode<TValue>>> fnActionWithPath) 
        {
            foreach(var rootNode in @this.Roots) {
                ForEach(rootNode, fnActionWithPath);
            }
        }


        public static void ForEach<TValue>(
                                this SimpleTreeNode<TValue> @this, 
                                Action<SimpleTreeNode<TValue>, IEnumerable<SimpleTreeNode<TValue>>> fnActionWithPath) 
        {
            ForEach(@this, fnActionWithPath, new Stack<SimpleTreeNode<TValue>>());
        }

        static void ForEach<TValue>(
                        this SimpleTreeNode<TValue> @this, 
                        Action<SimpleTreeNode<TValue>, IEnumerable<SimpleTreeNode<TValue>>> fnAction, 
                        Stack<SimpleTreeNode<TValue>> pathStack ) 
        {
            fnAction(@this, pathStack);

            pathStack.Push(@this);

            foreach(var childNode in @this.Children) {
                ForEach(childNode, fnAction, pathStack);
            }

            pathStack.Pop();
        }




        public static IEnumerable<SimpleTreeNode<TValue>> Flatten<TValue>(this SimpleTree<TValue> @this) 
        {
            return @this.Roots.SelectMany(r => Flatten(r));
        }

        public static IEnumerable<SimpleTreeNode<TValue>> Flatten<TValue>(this SimpleTreeNode<TValue> @this)
        {
            yield return @this;

            var descendents = @this.Children.SelectMany(c => Flatten(c));

            foreach(var descendent in descendents) {
                yield return descendent;
            }
        }



        public static SimpleTree<TNewItem> Project<TItem, TNewItem>(this SimpleTree<TItem> @this, Func<TItem, TNewItem> fnProject) 
        {
            return new SimpleTree<TNewItem>(
                            @this.Roots
                                    .Select(r => Project(r, fnProject))
                                    .ToArray()
                            );
        }

        public static SimpleTreeNode<TNewItem> Project<TItem, TNewItem>(this SimpleTreeNode<TItem> @this, Func<TItem, TNewItem> fnProject) 
        {
            return new SimpleTreeNode<TNewItem>(
                            fnProject(@this.Value),
                            @this.Children
                                    .Select(c => Project(c, fnProject))
                                    .ToArray()
                            );
        }





        public static SimpleTree<TNewItem> Project<TItem, TNewItem>(
                                                this SimpleTree<TItem> @this,
                                                Func<SimpleTreeNode<TItem>, IEnumerable<SimpleTreeNode<TItem>>, TNewItem> fnProject) 
        {
            return new SimpleTree<TNewItem>(
                            @this.Roots
                                    .Select(r => r.Project(fnProject))
                                    .ToArray()
                            );
        }

        public static SimpleTreeNode<TNewItem> Project<TItem, TNewItem>(
                                                    this SimpleTreeNode<TItem> @this,
                                                    Func<SimpleTreeNode<TItem>, IEnumerable<SimpleTreeNode<TItem>>, TNewItem> fnProject) 
        {
            return @this.Project(fnProject, new Stack<SimpleTreeNode<TItem>>());
        }


        static SimpleTreeNode<TNewItem> Project<TItem, TNewItem>(
                                            this SimpleTreeNode<TItem> @this,
                                            Func<SimpleTreeNode<TItem>, IEnumerable<SimpleTreeNode<TItem>>, TNewItem> fnProject,
                                            Stack<SimpleTreeNode<TItem>> stPath) 
        {
            stPath.Push(@this);

            var childNodes = @this.Children
                                    .Select(c => c.Project(fnProject, stPath))
                                    .ToArray();
            stPath.Pop();

            var newItem = fnProject(@this, stPath);

            return new SimpleTreeNode<TNewItem>(newItem, childNodes);
        }



    }
}
