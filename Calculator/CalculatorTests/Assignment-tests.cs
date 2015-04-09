using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.CheckBook;
using System.Collections.ObjectModel;
using System.Linq;

namespace CalculatorTests
{   [TestClass]
    public class Assignment_tests
    {
        [TestMethod]
        public void Average()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            //Calucating Total
            var total = ob.Transactions.GroupBy(t => t.Payee).Select(g => new { g.Key, Sum = g.Sum(t => t.Amount) });

            //Calculating Average
            var avg_m = total.ElementAt(0).Sum / ob.Transactions.Where(t => t.Payee == "Moshe").Count(); 
            var avg_t = total.ElementAt(1).Sum / ob.Transactions.Where(t => t.Payee == "Tim").Count();
            var avg_b = total.ElementAt(2).Sum / ob.Transactions.Where(t => t.Payee == "Bracha").Count();

            //Testing
            Assert.AreEqual(32.5, avg_m);
            Assert.AreEqual(75, avg_t);
            Assert.AreEqual(32.75, avg_b);

        }

        [TestMethod]
        public void Pay()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            //Calculating Total for each Payee
            var total = ob.Transactions.GroupBy(t => t.Payee).Select(g => new { g.Key, Sum = g.Sum(t => t.Amount) });

            //Testing
            Assert.AreEqual(130, total.ElementAt(0).Sum);
            Assert.AreEqual(300, total.ElementAt(1).Sum);
            Assert.AreEqual(131, total.ElementAt(2).Sum);

        }

       [TestMethod]
        public void Food()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            //Calculating Amount paid for Food by Each Payee
            var tag1 = ob.Transactions.Where(t => t.Tag == "Food").GroupBy(t => t.Payee);
            var tag2 = tag1.Select(g => new { g.Key, Sum = g.Sum(t => t.Amount) });
            
            //Testing
            Assert.AreEqual(130, tag2.ElementAt(0).Sum); //Amount paid by Moshe for Food
            Assert.AreEqual(131, tag2.ElementAt(1).Sum); //Amount paid by Bracha for Food          
                        
        }

        [TestMethod]
        public void Auto()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            // Calculating for MAX amount spent on Auto
            var tag = ob.Transactions.OrderBy(t => t.Amount).Where(t => t.Tag == "Auto");
            var tag2= tag.Select(t=>t.Account);
           
            //Testing
            Assert.AreEqual("Checking", tag2.ElementAt(0));
        }

        [TestMethod]
        public void Date()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            
            var d1 = new DateTime(2015,04,06);
            

            //Transaction between April 5th and 7th
            var d = ob.Transactions.Where(t=> t.Date==d1 ).Select(t=>t.Date);

            //Testing
            Assert.AreEqual(d1,d.ElementAt(0));
            Assert.AreEqual(d1,d.ElementAt(1));
            Assert.AreEqual(d1,d.ElementAt(2));
        
        }

        [TestMethod]
        public void DateForEachAccount()
        {
            var ob = new CheckBookVM();
            ob.Fill();
            var d1 = new DateTime(2015, 04, 01);
            var d2 = new DateTime(2015, 04, 03);
            var d3 = new DateTime(2015, 04, 04);
            var d4 = new DateTime(2015, 04, 05);
            var d5 = new DateTime(2015, 04, 06);
            var d6 = new DateTime(2015, 04, 07);

            //Dates on which each account was used
            var d = ob.Transactions.Select(t => t.Date);

            //Testing
            Assert.AreEqual(d4, d.ElementAt(0));
            Assert.AreEqual(d5, d.ElementAt(1));
            Assert.AreEqual(d3, d.ElementAt(2));
            Assert.AreEqual(d6, d.ElementAt(3));
            Assert.AreEqual(d5, d.ElementAt(4));
            Assert.AreEqual(d4, d.ElementAt(5));
            Assert.AreEqual(d5, d.ElementAt(6));
            Assert.AreEqual(d6, d.ElementAt(7));
            Assert.AreEqual(d4, d.ElementAt(8));
            Assert.AreEqual(d1, d.ElementAt(9));
            Assert.AreEqual(d4, d.ElementAt(10));
            Assert.AreEqual(d2, d.ElementAt(11));
          }
        [TestMethod]
        public void DateCount()
        {
            var ob = new CheckBookVM();
            ob.Fill();

            
            var d1 = new DateTime(2015, 04, 06);
            

            //No. of Transaction(s) between April 5th and 7th
            var dc = ob.Transactions.Where(t => t.Date == d1 ).Select(t => t.Date).Count();

            //Testing
            Assert.AreEqual(3, dc);
        }
        }
    }
