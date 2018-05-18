using FrameworkDemo.Pages;
using NUnit.Framework;

namespace FrameworkDemo
{
    public class Program
    {
        [TestFixture]

        class TimeMaterial : Global.Base
        {
            //Test case 1
            [Test]
            public void CreateTandM()
            {
                //Start the Add address test
                test = extent.StartTest("adding the TimeandMaterial");

                //Creating a Class
                TimeandMaterial obj = new TimeandMaterial();

                //Calling Method
                obj.CreatingTM();

            }

            //Test 2
            [Test]
            public void EditTandM()
            {
                //Start the Add address test
                test = extent.StartTest("Editing the TimeandMaterial");


                //Creating a Class
                TimeandMaterial obj = new TimeandMaterial();

                //Calling Method
                obj.EditTM();

            }

            //Test 3
            [Test]
            public void DeleteTandM()
            {
                //Start the Add address test
                test = extent.StartTest("Deleting the TimeandMaterial");


                //Creating a Class
                TimeandMaterial obj = new TimeandMaterial();

                //Calling Method
                obj.DeleteTM();

            }


        }
    }
}
