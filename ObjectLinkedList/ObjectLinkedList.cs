using System.Collections;

namespace ObjectLinkedList
{
    public class ObjectLinkedList : ICollection, IEnumerable, IList
    {
        Prvek? prvni = null;
        Prvek? posledni = null;
        class Prvek
        {
            public Prvek? predchozi;
            public Prvek? nasledujici;
            public Object? data;

            public Prvek(object data)
            {
                this.data = data;
            }
        }
        public object? this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count
        {
            get
            {
                int pocet = 0;
                IEnumerator enumerator = this.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    pocet++;
                }
                return pocet;
            }
        }

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public int Add(object? value)
        {
            if (value == null) return 0;
            Prvek novyPrvek = new Prvek(value);
            if (prvni == null)
            {
                prvni = novyPrvek;    
                posledni = novyPrvek;
                return 0;
            } else
            {
                posledni.nasledujici = novyPrvek;
                novyPrvek.predchozi = posledni;
                posledni = novyPrvek;
                return IndexOf(value);
            }
        }

        public void Clear()
        {
            prvni.nasledujici = null;
            posledni.predchozi = null;
            prvni = posledni = null;
        }

        public bool Contains(object? value)
        {
            IEnumerator enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Prvek prvek = (Prvek)enumerator.Current;
                if (prvek.data.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            Prvek? temp = prvni;
            while (temp != null)
            {
                yield return temp;
                temp = temp.nasledujici;
            }
        }

        public int IndexOf(object? value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object? value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object? value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}