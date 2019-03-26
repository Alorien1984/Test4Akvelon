using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable1
{
    class Spiders
    {
        private Suborders Suborder { get;}
        private SpidersFamilies Families { get; }
        private Gender Gender { get; }
        private int Lenght { get; }
        private string BornDate { get;}

        public Spiders(Suborders _suborder, SpidersFamilies _family, Gender _gender, int _lenght, string _bornDate)
        {
            Suborder = _suborder;
            Families = _family;
            Gender = _gender;
            Lenght = _lenght;
            BornDate = _bornDate;
        }

        protected bool Equals(Spiders other)
        {
            return Suborder == other.Suborder && Families == other.Families && Gender == other.Gender;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Spiders)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Suborder;
                hashCode = (hashCode * 397) ^ (int)Families;
                hashCode = (hashCode * 397) ^ (int)Gender;
                return hashCode;
            }
        }
    }
}
