using System.Web.Mvc;
using NUnit.Framework;

namespace Tests.Unit.Helpers
{
    public static class ViewHelpers
    {
        public static void VerifyViewNameIsSameAsMethodName(ViewResult viewResult)
        {
            // ViewName will be blank if the name of the View is not specified.
            Assert.AreEqual("", viewResult.ViewName, "View name is different than method name");
        }
    }
}