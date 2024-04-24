using System;
using System.Collections.Generic;


namespace SwinAdventure
{
    public class IdentifiableObject
    {
        public List<string> _identifiers;
        
         public IdentifiableObject(string[] idents)
         {
            _identifiers = new List<string>();


            foreach (string ident in idents)
            {

                AddIdentifier(ident);
            }
         }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }
        public string firstID 
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];

                }
                else
                {
                    return "";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }

}