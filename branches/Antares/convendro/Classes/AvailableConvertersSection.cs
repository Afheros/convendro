using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace convendro.Classes {
    /// <summary>
    /// 
    /// </summary>
    public class AvailableConvertersSection : ConfigurationSection {

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("name",
                DefaultValue = "Converters",
                IsRequired = true,
                IsKey = false)]       
        public string Name {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("ConvertersList",
            IsDefaultCollection = false)]
        public AvailableConvertersCollection ConvertersList {
            get {
                AvailableConvertersCollection colCollection = (AvailableConvertersCollection)base["ConvertersList"];
                return colCollection;
            }
        }


    }

    public class AvailableConvertersCollection : ConfigurationElementCollection {

        /// <summary>
        /// 
        /// </summary>
        public AvailableConvertersCollection() {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement() {
            return new AvailableConverter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement(string elementName) {
            return new AvailableConverter(elementName);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element) {
            return ((AvailableConverter)element).Name;
        }

        /// <summary>
        /// 
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType {
            get {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public new string AddElementName {
            get { return base.AddElementName; }
            set { base.AddElementName = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public new string ClearElementName {
            get { return base.ClearElementName; }
            set { base.ClearElementName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public new string RemoveElementName {
            get { return base.RemoveElementName; }
            set { base.RemoveElementName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public new int Count {
            get { return base.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AvailableConverter this[int index] {
            get { return (AvailableConverter)BaseGet(index); }
            set {
                if (BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public new AvailableConverter this[string name] {
            get { return (AvailableConverter)BaseGet(name); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="converter"></param>
        /// <returns></returns>
        public int IndexOf(AvailableConverter converter) {
            return BaseIndexOf(converter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="converter"></param>
        public void Add(AvailableConverter converter) {
            BaseAdd(converter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        protected override void BaseAdd(ConfigurationElement element) {
            // throw an error...
            base.BaseAdd(element);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="converter"></param>
        public void Remove(AvailableConverter converter) {
            if (BaseIndexOf(converter) >= 0) {
                BaseRemove(converter.Name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            BaseClear();
        }
    }

    /// <summary>
    ///   
    /// </summary>
    public class AvailableConverter : ConfigurationElement {       

        /// <summary>
        /// 
        /// </summary>
        public AvailableConverter() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convertername"></param>
        /// <param name="filelocation"></param>
        public AvailableConverter(string convertername) : this() {
            Name = convertername;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name {
            get {
                return (string)this["name"];
            }

            set {
                this["name"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("filename", IsRequired = true)]
        public string Filename {
            get {
                return (string)this["filename"];
            }

            set {
                this["filename"] = value;               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="serializeCollectionKey"></param>
        protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey) {
            base.DeserializeElement(reader, serializeCollectionKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="serializeCollectionKey"></param>
        /// <returns></returns>
        protected override bool SerializeElement(System.Xml.XmlWriter writer, bool serializeCollectionKey) {
            return base.SerializeElement(writer, serializeCollectionKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool IsModified() {
            return base.IsModified();
        }

    }

}
