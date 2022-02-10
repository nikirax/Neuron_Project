using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuronProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronProject.Tests
{
    [TestClass()]
    public class PictureConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new PictureConverter();
            var inputs = converter.Convert(@"C:\Users\KokoKola\source\repos\NeuronProject\NeuronProject\Images\Parazit.png");
            converter.Save(@"C:\Users\KokoKola\source\repos\NeuronProject\NeuronProject\ImagesBW\picture.png", inputs);
        }
    }
}