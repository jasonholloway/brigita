using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nop.Core.Domain.Catalog;
using FizzWare.NBuilder;
using Sequences;
using Brigita.Services.Categories;
using Brigita.Services.Test.Infrastructure;
using Brigita.Services.Cache;
using System.Runtime.Caching;
using Brigita.Core.Infrastructure.Trees;
using System.Collections.Generic;
using Brigita.Domain.Scope;
using FluentAssertions;
using Brigita.Domain.Categories;

namespace Brigita.Services.Test
{
    [TestClass]
    public class CategoryTests
    {
        static ICategory[] _allCats;

        static CategoryTests() {
            var catIDs = new List<int>(new[] { 0 });

            _allCats = Builder<NopCategory>.CreateListOfSize(100)
                                            .All()
                                                .Do(c => c.ParentCategoryId = Pick<int>.RandomItemFrom(catIDs))
                                                .Do(c => catIDs.Add(c.ID))
                                            .Build()
                                            .Cast<ICategory>().ToArray();
        }
        

        [TestMethod]
        public void ArticulateCategoryTree() 
        {
            var repo = new RepositoryMock<NopCategory>(_allCats.Cast<NopCategory>());
            var cats = new BrigitaCategories(repo);

            var catTree = cats.Tree;


            var catIDsInTree = new HashSet<int>(catTree.Flatten().Select(n => n.Value.ID));

            Assert.IsTrue(
                _allCats.All(c => catIDsInTree.Contains(c.ID)),
                "Some cats missing from tree!"
                );
            

            catTree.ForEach(
                (node, path) => {
                    var cat = node.Value;

                    Assert.IsTrue(
                        (cat.ParentCategoryId == 0 && !path.Any())
                        || (cat.ParentCategoryId == path.First().Value.ID),
                        "Node parentage incorrect"
                        );
                });
        }


        [TestMethod]
        public void ScopedCategoryTree() 
        {
            var repo = new RepositoryMock<NopCategory>(_allCats.Cast<NopCategory>());
            var cats = new BrigitaCategories(repo);
            var scopedCats = new ScopedCategories(cats);
            

            var catIDs = _allCats.Select(c => c.ID);

            var treeTups = catIDs.Select(cid => new { 
                                                    CatID = cid,
                                                    Tree = scopedCats.GetTree(new PageScope() {
                                                                                        CategoryID = cid
                                                                                        })
                                                });


            foreach(var treeTup in treeTups) {
                var activeCatID = treeTup.CatID;
                var scopedCatTree = treeTup.Tree;
                
                scopedCatTree.ForEach(
                        (node, path) => {
                            var cat = node.Value;

                            if(cat.IsActive) {
                                Assert.IsTrue(cat.ID == activeCatID);
                            }
                            else {
                                Assert.IsTrue(cat.ID != activeCatID);
                            }

                            if(cat.IsActiveParent) {
                                Assert.IsTrue(node.Flatten()
                                                    .Any(cn => cn.Value.ID == activeCatID),
                                              "ActiveParent flag set to true, yet no active child found!");
                            }
                            else {
                                Assert.IsTrue(node.Flatten()
                                                    .All(cn => cn.Value.ID != activeCatID),
                                              "ActiveParent flag set to false, yet active child found!");
                            }
                        });
            }
        }



    }
}
