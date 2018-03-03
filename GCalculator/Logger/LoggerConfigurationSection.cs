using System.Configuration;

namespace Logger
{
    internal class LoggerConfigurationSection: ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public ConfigInstanceCollection Instances
        {
            get => (ConfigInstanceCollection)this[""];
            set => this[""] = value;
        }
    }

    internal class ConfigInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigInstanceElement)element).Name;
        }
    }

    internal class ConfigInstanceElement : ConfigurationElement
    {
        //just for readability
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get => (string)base["name"];
            set => base["name"] = value;
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get => (string)base["type"];
            set => base["type"] = value;
        }
    }
}