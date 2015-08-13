using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom.Services.Categories;
using Brigita.Infrastructure.Trees;

namespace Brigita.Queries.Menu
{
    public class MenuHandler : IQueryHandler<MenuQuery, MenuModel> 
    {
        IScopedCategories _scopedCats;
        ILinkProvider _links;

        public MenuHandler(IScopedCategories scopedCats, ILinkProvider links) 
        {
            _scopedCats = scopedCats;
            _links = links;
        }
        
        public MenuModel Enquire(MenuQuery query) 
        {
            var catTree = _scopedCats.GetTree(query.ActiveCategoryID);

            var menuTree = catTree.Project(cat => new MenuItemModel() {
                Name = cat.Name,
                Link = _links.GetLinkFor(cat),
                IsActive = cat.IsActive,
                IsActiveParent = cat.IsActiveParent
            });

            return new MenuModel() {
                MenuItemTree = menuTree
            };
        }
    }
}
