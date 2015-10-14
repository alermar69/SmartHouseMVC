using System;

namespace SmartHouseDll
{
    [Serializable]
    public abstract class Authentication
    {
        private string _name;
        private string _nameId;

        protected Authentication(string name)
        {
            Name = name;
            NameId = Name.ToLower();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NameId = Name.ToLower();
            }
        }

        public string NameId
        {
            get { return _nameId; }
            set { _nameId = value; }
        }
    }
}