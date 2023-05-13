using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            StreamReader r = new StreamReader("utca.txt");
            string line = r.ReadLine();
            string[] splitted = line.Split(' ');
            Program.Adosav.Add("A", int.Parse(splitted[0]));
            Program.Adosav.Add("B", int.Parse(splitted[1]));
            Program.Adosav.Add("C", int.Parse(splitted[2]));
            Assert.AreEqual(18000, Program.ado("C",180));
            Assert.AreEqual(33600, Program.ado("B", 56));
            Assert.AreEqual(96000, Program.ado("A", 120));
            Assert.AreEqual(0, Program.ado("C", 64));
        }
    }
}