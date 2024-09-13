using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp30.Program.SubsystemC;

namespace ConsoleApp30
{
    internal class Program
    {

        public class SubsystemA
        {
            public void A1()
            {

            }

            public void SubsystemA0()
            {

            }
        }


        public class SubsystemB
        {
            public void B1()
            {

            }

            public void SubsystemB0()
            {

            }
        }

        public class SubsystemC
        {
            public void C1()
            {

            }

            public void SubsystemC0()
            {

            }


            public class Facade
            {
                private SubsystemA subsystemA;
                private SubsystemB subsystemB;
                private SubsystemC subsystemC;

                public Facade()
                {
                    subsystemA = new SubsystemA();
                    subsystemB = new SubsystemB();
                    subsystemC = new SubsystemC();
                }

                public void Operation1()
                {

                    subsystemA.A1();
                    subsystemB.B1();
                    subsystemC.C1();
                }

                public void Operation2()
                {

                    subsystemA.SubsystemA0();
                    subsystemB.SubsystemB0();
                    subsystemC.SubsystemC0();
                }
            }

            //Адаптер


            public class Target
            {
                public virtual void Request()
                {
                    Console.WriteLine("Изначальный");
                }
            }


            public class Adaptee
            {
                public void SpecificRequest()
                {
                    Console.WriteLine("Адаптер");
                }
            }


            public class Adapter : Target
            {
                private readonly Adaptee adaptee;

                public Adapter(Adaptee adaptee)
                {
                    this.adaptee = adaptee;
                }

                public override void Request()
                {
                    adaptee.SpecificRequest();
                }
            }


            public class Client
            {
                public void Request(Target target)
                {
                    target.Request();
                }
            }
            static void Main(string[] args)
            {
                Facade facade = new Facade();
                facade.Operation1();
                facade.Operation2();

                //Aдаптер

                Client client = new Client();
                Target target = new Target();
                client.Request(target);
                Adaptee adaptee = new Adaptee();
                Target adapter = new Adapter(adaptee);
                client.Request(adapter);
            }
        }
    }
}
