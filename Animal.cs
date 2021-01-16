using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePracticeList
{
    class Animal
    {
        public enum Size
        {
            None,
            Large, 
            Medium, 
            Small
        }

        private string _name;
        private int _weight;
        private bool _isMammal;
        private Size _bodySize;

        public Size BodySize
        {
            get { return _bodySize; }
            set { _bodySize = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool IsMammal
        {
            get { return _isMammal; }
            set { _isMammal = value; }
        }

        public string DisplayInfo()
        {
            return $"The animal {_name} weighs {_weight} pounds and has a {_bodySize} body size and is a {_isMammal}!";
        }

        public Animal()
        {

        }

        public Animal(string name, int weight, Size bodySize, bool mammal)
        {
            _name = name;
            _weight = weight;
            _bodySize = bodySize;
            _isMammal = mammal;
        }
    }
}
