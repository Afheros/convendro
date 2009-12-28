using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Reflection;

namespace libconvendro.Plugins {

    public delegate void pluginevent (object anobject, IConvendroPlugin plugin);

    public class PluginManager {
        private string pluginfolder = null;
        private ArrayList plugins = new ArrayList();
        public event pluginevent OnPluginLoad = null;       

        /// <summary>
        /// 
        /// </summary>
        public PluginManager (){
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginfolder"></param>
        public PluginManager(string pluginfolder) : this() {
            if (!String.IsNullOrEmpty(pluginfolder)) {
                this.pluginfolder = pluginfolder;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public string PluginFolder {
            get { return this.pluginfolder; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Load() {            
            this.loadPlugins();
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadPlugins() {
            string[] dirinfo = Directory.GetFiles(this.pluginfolder, "*.dll");
            
            foreach (string sfile in dirinfo) {
                if (!String.IsNullOrEmpty(sfile)) {
                    Assembly asm = Assembly.LoadFrom(sfile);

                    Type[] arraytypes = asm.GetTypes();

                    foreach (Type atype in arraytypes) {
                        if (atype != null) {
                            object iobj = Activator.CreateInstance(atype);

                            if (iobj != null) {

                                if (iobj is IConvendroPlugin) {
                                    
                                    plugins.Add((IConvendroPlugin)iobj);
                                    if (OnPluginLoad != null) {
                                        OnPluginLoad(this, (IConvendroPlugin) iobj);
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }


    }
}
