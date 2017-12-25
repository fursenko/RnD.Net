
namespace Tr.ReferencesEquals
{
    using System;
    using System.Diagnostics;

    class A
    {
        public string Name { get; set; }

        public A(string name = null)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A("1");
            var b = new A("1");

            var strA = "1.";
            var strB = "1";

            Debug.WriteLine(" a == b : {0}", strA == strB); // compare intsnces
            Debug.WriteLine(" a.Equals(b) : {0}", strA.Equals(strB)); // compare intsnces
            Debug.WriteLine(" Object.ReferenceEquals(a, b) : {0}", Object.ReferenceEquals(strA, strB)); // compare references

            strB += ".";

            Debug.WriteLine(" a == b : {0}", strA == strB);
            Debug.WriteLine(" a.Equals(b) : {0}", Object.Equals(new A(), new A()));
            Debug.WriteLine(" Object.ReferenceEquals(a, b) : {0}", Object.ReferenceEquals(strA, strB));

            Debug.WriteLine(" a.Equals(b) : {0}", a.Equals(b));
            Debug.WriteLine(" Object.Equals(a, b) : {0}", Object.Equals(a, b));

            var b1 = b;

            Debug.WriteLine(" a.Equals(b) : {0}", b1.Equals(b));
            Debug.WriteLine(" Object.ReferenceEquals(a, b) : {0}", Object.ReferenceEquals(b, b1));
        }
    }
}
