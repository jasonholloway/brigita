using Nop.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Plugins
{
    public class BrigitaPluginFinder : IPluginFinder
    {
        public bool AuthenticateStore(PluginDescriptor pluginDescriptor, int storeId) {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetPluginGroups() {
            return new string[0];
        }

        public IEnumerable<T> GetPlugins<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly, int storeId = 0, string group = null) 
            where T : class, IPlugin 
        {
            return new T[0];
        }

        public IEnumerable<PluginDescriptor> GetPluginDescriptors(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly, int storeId = 0, string group = null) 
        {
            return new PluginDescriptor[0];
        }

        public IEnumerable<PluginDescriptor> GetPluginDescriptors<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly, int storeId = 0, string group = null) 
            where T : class, IPlugin 
        {
            return new PluginDescriptor[0];
        }

        public PluginDescriptor GetPluginDescriptorBySystemName(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly) {
            return null;
        }

        public PluginDescriptor GetPluginDescriptorBySystemName<T>(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly) where T : class, IPlugin {
            return null;
        }

        public void ReloadPlugins() {
            //...
        }
    }
}
