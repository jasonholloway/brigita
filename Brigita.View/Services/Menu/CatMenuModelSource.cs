﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom.Services.Categories;
using Brigita.View.Menu;
using Brigita.Infrastructure.Trees;

namespace Brigita.View.Services.Menu
{
    public class CatMenuModelSource : ICatMenuModelSource
    {
        IScopedCategories _scopedCats;
        ILinkProvider _links;

        public CatMenuModelSource(IScopedCategories scopedCats, ILinkProvider links) {
            _scopedCats = scopedCats;
            _links = links;
        }
        
        public CategoryMenuModel GetModel(int activeCatID = 0) 
        {
            var catTree = _scopedCats.GetTree(activeCatID);

            var menuTree = catTree.Project(cat => new CategoryMenuItem() {
                Name = cat.Name,
                Link = _links.GetLinkFor(cat),
                IsActive = cat.IsActive,
                IsActiveParent = cat.IsActiveParent
            });

            return new CategoryMenuModel() {
                MenuItemTree = menuTree
            };
        }
    }
}
