using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KillDuties.Utility.DateTimeExtension.UnitTest
{
    [TestClass]
    public class ChangeCalendarUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime date = DateTime.Now.Date;
            var result = date.GetCalendarChangedList(CalendarFormat.Taiwan);
            Assert.AreEqual(108, result[0]);
            Assert.AreEqual(8, result[1]);
            Assert.AreEqual(9, result[2]);

            result = date.GetCalendarChangedList(CalendarFormat.Japanese);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(8, result[1]);
            Assert.AreEqual(9, result[2]);
        }
    }
}
