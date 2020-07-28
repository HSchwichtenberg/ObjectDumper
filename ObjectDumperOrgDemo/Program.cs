using System;
using System.Collections.Generic;

namespace ObjectDumperOrgDemo
{
    public enum KnowhowLevel
    {
        KeinWissen, Einsteiger, Fortgeschritten, Experte, TopExperte
    }

    public struct Knowhow
    {
        public string Thema { get; set; }
        public KnowhowLevel KnowhowLevel { get; set; }
    }

    public class Softwareentwickler
    {
        public string Name { get; set; }
        public Uri Website { get; set; }
        public int Geburtsjahr { get; set; }
        public List<Knowhow> KnowhowSet { get; set; }
        public Firma Firma { get; set; }

        public override string ToString()
        {
            return Name + " *" + Geburtsjahr + ": " + Website;
        }
    }

    public struct Firma
    {
        public string Name { get; set; }
        public Softwareentwickler Inhaber { get; set; }
        public DateTime Gruendungsdatum { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START...");

            var obj = new Softwareentwickler { Name = "Dr. Holger Schwichtenberg", Website = new Uri("https://www.dotnet-doktor.de"), Geburtsjahr = 1972 };
           Console.WriteLine("---------- Ein Objekt / MaxLevel=0");
            var s0 = ObjectDumper.Dump(obj, new DumpOptions() { MaxLevel = 0 });
            Console.WriteLine(s0);
            Console.WriteLine("---------- Ein Objekt / MaxLevel=1");
            var s1 = ObjectDumper.Dump(obj, new DumpOptions() { MaxLevel = 1 });
            Console.WriteLine(s1);
            Console.WriteLine("---------- Ein Objekt / MaxLevel=2");
            var s2 = ObjectDumper.Dump(obj, new DumpOptions() { MaxLevel = 2 });
            Console.WriteLine(s2);


            obj.KnowhowSet = new List<Knowhow>();
            obj.KnowhowSet.Add(new Knowhow() { Thema = "Blazor", KnowhowLevel = KnowhowLevel.TopExperte });
            obj.KnowhowSet.Add(new Knowhow() { Thema = "Entity Framework", KnowhowLevel = KnowhowLevel.TopExperte });
            obj.KnowhowSet.Add(new Knowhow() { Thema = "C#", KnowhowLevel = KnowhowLevel.TopExperte });
            obj.KnowhowSet.Add(new Knowhow() { Thema = "WPF", KnowhowLevel = KnowhowLevel.Experte });
            obj.KnowhowSet.Add(new Knowhow() { Thema = "Java", KnowhowLevel = KnowhowLevel.Fortgeschritten });
            obj.KnowhowSet.Add(new Knowhow() { Thema = "Cobol", KnowhowLevel = KnowhowLevel.KeinWissen });

            //var s3 = ObjectDumper.Dump(obj, new DumpOptions() { MaxLevel = 3, IncludeClassNames=false });
            //Console.WriteLine(s3);

            Console.WriteLine("----------Ein Objektbaum mit Rekursion / MaxLevel=3");
            var f = new Firma() { Name = "www.IT-Visions.de", Inhaber = obj, Gruendungsdatum = new DateTime(1996, 1, 1) };
            obj.Firma = f;
            var s4 = ObjectDumper.Dump(obj, new DumpOptions() { MaxLevel = 3 });
            Console.WriteLine(s4);

            Console.ReadLine();
        }
    }
}
