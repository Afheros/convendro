using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace libconvendro.Plugins {
    public class BaseConvendroPlugin : IConvendroPlugin{

        #region IConvendroPlugin Members

        private string name = null;
        private readonly Guid guid = Guid.NewGuid();
        private IConvendroHost host;

        public string Name {
            get { return this.name; }
        }

        public Guid Guid {
            get { return this.guid; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool Execute() {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConvendroHost Host {
            get {
                return this.host;
            }
            set {
                this.host = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void setName() {
            this.name = this.GetType().FullName;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Initialize() {
            this.setName();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Uninitialize() {

        }

        #endregion

        #region IConvendroPlugin Members


        public string Description {
            get { return this.Description; }
        }

        public string Author {
            get { throw new NotImplementedException(); }
        }

        public string CopyrightInformation {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IConvendroPlugin Members


        public Version Version {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
