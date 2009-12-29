using System;
using System.Collections.Generic;
using System.Text;
using libconvendro.Plugins;
using System.Windows.Forms;
using System.IO;

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
            // override default Guid in Baseclass.
            this.Guid = new Guid("01716dc3-2d75-416c-8a37-ff32ad4011f3");
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

            string filename = "noname unknown haha...";

            if (this.Host != null) {
                if (this.Host.SelectedIndices.Length > 0) {
                    int i = this.Host.SelectedIndices[0];

                    ListViewItem item = this.Host.GetFileListViewItem(i);

                    if (item != null) {
                        filename = Path.Combine(
                            item.SubItems[libconvendro.Threading.FFMPEGConverter.SUBCOL_PATH].Text,
                            item.SubItems[libconvendro.Threading.FFMPEGConverter.SUBCOL_FILENAME].Text);
                    }
                }
            }

            return (MessageBox.Show("Hello World " + 
                this.Author + " | " + this.Description + " | " +
                this.Version.ToString() + " | selected file :" + filename) == DialogResult.OK);
        }
    }
}
