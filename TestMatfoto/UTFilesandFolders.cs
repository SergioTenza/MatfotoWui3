using MatfotoWui3.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMatfoto
{
    [TestClass]
    public class UTFilesandFolders
    {
        [TestMethod]
        public void TestFutureAccessFoldersIsEmpty()
        {
            var test = StorageFolderHelpers.FutureAccessListEmpty();            
            Assert.IsFalse(test);
        }
    }
}
