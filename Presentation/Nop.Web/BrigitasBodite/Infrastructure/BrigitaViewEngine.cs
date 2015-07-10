using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Brigita.Infrastructure
{
    public class BrigitaViewEngine : VirtualPathProviderViewEngine
    {
        
        //the original implementation can be found at http://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Mvc/VirtualPathProviderViewEngine.cs

        #region Fields

        private const string CacheKeyFormat = ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}:{5}";
        private const string CacheKeyPrefixMaster = "Master";
        private const string CacheKeyPrefixPartial = "Partial";
        private const string CacheKeyPrefixView = "View"; 
        private static readonly string[] _emptyLocations = new string[0];

        internal Func<string, string> GetExtensionThunk = VirtualPathUtility.GetExtension;

        #endregion

        IThemeContext _themeContext;

        public BrigitaViewEngine()
        {
            _themeContext = EngineContext.Current.Resolve<IThemeContext>();
        }

        #region Utilities & Methods

        protected virtual string GetAreaName(RouteData routeData)
        {
            object result;
            if (routeData.DataTokens.TryGetValue("area", out result))
            {
                return (result as string);
            }
            return GetAreaName(routeData.Route);
        }

        protected virtual string GetAreaName(RouteBase route)
        {
            var area = route as IRouteWithArea;
            if (area != null)
            {
                return area.Area;
            }
            var route2 = route as Route;
            if ((route2 != null) && (route2.DataTokens != null))
            {
                return (route2.DataTokens["area"] as string);
            }
            return null;
        }

        internal virtual string CreateCacheKey(string prefix, string name, string controllerName, string areaName, string theme)
        {
            return String.Format(CultureInfo.InvariantCulture, CacheKeyFormat,
                                 GetType().AssemblyQualifiedName, prefix, name, controllerName, areaName, theme);
        }

        internal static string AppendDisplayModeToCacheKey(string cacheKey, string displayMode)
        {
            return cacheKey + displayMode + ":";
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Partial view name cannot be null or empty.", "partialViewName");
            }

            if(partialViewName == "Head")
            {

            }

            var searched = new List<string>();

            string theme = _themeContext.WorkingThemeName;
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string partialPath = GetPath(controllerContext, PartialViewLocationFormats, AreaPartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, controllerName, theme, CacheKeyPrefixPartial, useCache, searched);

            if (String.IsNullOrEmpty(partialPath))
            {
                return new ViewEngineResult(searched);
            }

            return new ViewEngineResult(CreatePartialView(controllerContext, partialPath), this);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException("View name cannot be null or empty.", "viewName");
            }

            var viewLocationsSearched = new List<string>();
            var masterLocationsSearched = new List<string>();

            string theme = _themeContext.WorkingThemeName;
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string viewPath = GetPath(controllerContext, ViewLocationFormats, AreaViewLocationFormats, "ViewLocationFormats", viewName, controllerName, theme, CacheKeyPrefixView, useCache, viewLocationsSearched);
            string masterPath = GetPath(controllerContext, MasterLocationFormats, AreaMasterLocationFormats, "MasterLocationFormats", masterName, controllerName, theme, CacheKeyPrefixMaster, useCache, masterLocationsSearched);

            if (String.IsNullOrEmpty(viewPath) || (String.IsNullOrEmpty(masterPath) && !String.IsNullOrEmpty(masterName)))
            {
                return new ViewEngineResult(viewLocationsSearched.Union(masterLocationsSearched));
            }

            return new ViewEngineResult(CreateView(controllerContext, viewPath, masterPath), this);
        }

        private string GetPath(
            ControllerContext controllerContext, 
            string[] locations, 
            string[] areaLocations, 
            string locationsPropertyName, 
            string name, 
            string controllerName, 
            string theme, 
            string cacheKeyPrefix, 
            bool useCache, 
            List<string> searchedLocations )
        {
            if (String.IsNullOrEmpty(name))
            {
                return String.Empty;
            }

            string areaName = (GetAreaName(controllerContext.RouteData)
                                ?? string.Empty);

            switch(areaName.ToLower())
            {
                case "admin":
                    locations = new[] {
                        "~/Administration/Views/{1}/{0}.cshtml",
                        "~/Administration/Views/Shared/{0}.cshtml"
                    };
                    break;

                case "brigita":
                    locations = new[] {
                        "~/BrigitasBodite/Themes/{2}/Views/{1}/{0}.cshtml",
                        "~/BrigitasBodite/Themes/{2}/Views/Shared/{0}.cshtml",
                        "~/BrigitasBodite/Views/{1}/{0}.cshtml",
                        "~/BrigitasBodite/Views/Shared/{0}.cshtml"
                    };

                    theme = "Brigita";
                    break;

                default:
                    locations = new[] {
                        "~/Themes/{2}/Views/{1}/{0}.cshtml",
                        "~/Themes/{2}/Views/Shared/{0}.cshtml",
                        "~/Views/{1}/{0}.cshtml",
                        "~/Views/Shared/{0}.cshtml"
                    };

                    theme = "DefaultClean";
                    break;
            }

            //bool usingAreas = !String.IsNullOrEmpty(areaName);
            //List<ViewLocation> viewLocations = GetViewLocations(locations, (usingAreas) ? areaLocations : null);

            bool nameRepresentsPath = IsSpecificPath(name);

            string cacheKey = CreateCacheKey(
                                        cacheKeyPrefix, 
                                        name, 
                                        (nameRepresentsPath) ? String.Empty : controllerName, 
                                        areaName, 
                                        theme
                                        );

            var viewLocations = locations.Select(l => new ViewLocation(l));

            if (useCache)
            {
                // Only look at cached display modes that can handle the context.
                var possibleDisplayModes = DisplayModeProvider.GetAvailableDisplayModesForContext(
                                                                                    controllerContext.HttpContext, 
                                                                                    controllerContext.DisplayMode 
                                                                                    );

                foreach (var displayMode in possibleDisplayModes)
                {
                    string cachedLocation = ViewLocationCache.GetViewLocation(
                                                                    controllerContext.HttpContext, 
                                                                    AppendDisplayModeToCacheKey(cacheKey, displayMode.DisplayModeId)
                                                                    );

                    if (cachedLocation == null)
                    {
                        // If any matching display mode location is not in the cache, fall back to the uncached behavior, which will repopulate all of our caches.
                        return null;
                    }

                    // A non-empty cachedLocation indicates that we have a matching file on disk. Return that result.
                    if (cachedLocation.Length > 0)
                    {
                        if (controllerContext.DisplayMode == null)
                        {
                            controllerContext.DisplayMode = displayMode;
                        }

                        return cachedLocation;
                    }
                    // An empty cachedLocation value indicates that we don't have a matching file on disk. Keep going down the list of possible display modes.
                }

                // GetPath is called again without using the cache.
                return null;
            }
            else
            {
                return nameRepresentsPath
                        ? GetPathFromSpecificName(controllerContext, name, cacheKey, searchedLocations)
                        : GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, cacheKey, searchedLocations);
            }
        }


        private string GetPathFromGeneralName(ControllerContext controllerContext, IEnumerable<ViewLocation> viewLocations, string name, string controllerName, string areaName, string theme, string cacheKey, List<string> searchedLocations)
        {
            foreach(var viewLocation in viewLocations) 
            {
                string virtualPath = viewLocation.Format(name, controllerName, null, theme);

                searchedLocations.Add(name);

                var displayInfo = DisplayModeProvider.GetDisplayInfoForVirtualPath(
                                                            virtualPath,
                                                            controllerContext.HttpContext,
                                                            path => FileExists(controllerContext, path),
                                                            controllerContext.DisplayMode
                                                            );

                if(displayInfo != null)
                {
                    string filePath = displayInfo.FilePath;

                    ViewLocationCache.InsertViewLocation(
                                        controllerContext.HttpContext,
                                        AppendDisplayModeToCacheKey(cacheKey, displayInfo.DisplayMode.DisplayModeId),
                                        filePath
                                        );

                    if(controllerContext.DisplayMode == null) {
                        controllerContext.DisplayMode = displayInfo.DisplayMode;
                    }

                    // Populate the cache for all other display modes. We want to cache both file system hits and misses so that we can distinguish
                    // in future requests whether a file's status was evicted from the cache (null value) or if the file doesn't exist (empty string).

                    var otherDisplayModes = DisplayModeProvider.Modes
                                                .Where(m => m.DisplayModeId != displayInfo.DisplayMode.DisplayModeId);

                    foreach(var otherDisplayMode in otherDisplayModes)
                    {
                        var otherDisplayInfo = otherDisplayMode.GetDisplayInfo(
                                                                controllerContext.HttpContext,
                                                                virtualPath,
                                                                path => FileExists(controllerContext, path)
                                                                );

                        if(otherDisplayInfo != null)
                        {
                            string otherFilePath = otherDisplayInfo.FilePath ?? string.Empty;

                            ViewLocationCache.InsertViewLocation(
                                                    controllerContext.HttpContext,
                                                    AppendDisplayModeToCacheKey(cacheKey, otherDisplayMode.DisplayModeId),
                                                    otherFilePath
                                                    );
                        }
                    }

                    return filePath;
                }
            }

            return string.Empty;
        }



        private string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, List<string> searchedLocations)
        {
            string result = name;

            if (!(FilePathIsSupported(name) && FileExists(controllerContext, name)))
            {
                result = String.Empty;
                searchedLocations.Add(name);
            }

            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, result);
            return result;
        }

        private bool FilePathIsSupported(string virtualPath)
        {
            if (FileExtensions == null)
            {
                // legacy behavior for custom ViewEngine that might not set the FileExtensions property
                return true;
            }
            else
            {
                // get rid of the '.' because the FileExtensions property expects extensions withouth a dot.
                string extension = GetExtensionThunk(virtualPath).TrimStart('.');
                return FileExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
            }
        }

        private static List<ViewLocation> GetViewLocations(string[] viewLocationFormats, string[] areaViewLocationFormats)
        {
            List<ViewLocation> allLocations = new List<ViewLocation>();

            if (areaViewLocationFormats != null)
            {
                foreach (string areaViewLocationFormat in areaViewLocationFormats)
                {
                    allLocations.Add(new AreaAwareViewLocation(areaViewLocationFormat));
                }
            }

            if (viewLocationFormats != null)
            {
                foreach (string viewLocationFormat in viewLocationFormats)
                {
                    allLocations.Add(new ViewLocation(viewLocationFormat));
                }
            }

            return allLocations;
        }

        private static bool IsSpecificPath(string name)
        {
            char c = name[0];
            return (c == '~' || c == '/');
        }

        #endregion

        #region Nested classes

        public class AreaAwareViewLocation : ViewLocation
        {
            public AreaAwareViewLocation(string virtualPathFormatString)
                : base(virtualPathFormatString)
            {
            }

            public override string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, areaName, theme);
            }
        }

        public class ViewLocation
        {
            protected readonly string _virtualPathFormatString;

            public ViewLocation(string virtualPathFormatString)
            {
                _virtualPathFormatString = virtualPathFormatString;
            }

            public virtual string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, theme);
            }
        }
        #endregion
    }
}