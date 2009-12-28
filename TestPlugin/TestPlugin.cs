using System;
using System.Collections.Generic;
using System.Text;
using libconvendro.Plugins;
using System.Windows.Forms;

namespace TestPlugin {
    public class TestPlugin : BaseConvendroPlugin  {
        /// <summary>
        /// 
        /// </summary>
        private void setupInternals() {
            this.Author = "Arthur Hoogervorst";
            this.CopyrightInformation = "Copyrights 2009 Arthur Hoogervorst";
            this.Description = "A test plugin for convendro";
            this.Version = new Version("1.0.0.0");
            this.MenuBitmap = Properties.Resources.address_book_new;
        }

        /// <summary>
        /// 
        /// </summary>
        public TestPlugin() {
            this.setupInternals();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize() {           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Execute() {
            return (MessageBox.Show("Hello World " + 
                this.Author + " | " + this.Description + " | " +
                this.Version.ToString()) == DialogResult.OK);
        }
    }
}
