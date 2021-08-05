using MatfotoWui3.Core.Contracts.Services;
using MatfotoWui3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatfotoWui3.Core.Services
{
    public class DataService : IDataService
    {
        private IList<Folder> _folders;
        private IList<SingleWork> _singleWorks;

        public DataService()
        {
            _folders = new List<Folder>();
            _singleWorks = new List<SingleWork>();
        }

        public int AddFolder(Folder item)
        {
            item.Id = _folders.Max(i => i.Id) + 1;
            _folders.Add(item);

            return item.Id;
        }

        public int AddWork(SingleWork item)
        {
            item.Id = _singleWorks.Max(i => i.Id) + 1;
            _singleWorks.Add(item);

            return item.Id;
        }

        public Folder GetFolder(int id)
        {
            return _folders.FirstOrDefault(i => i.Id == id);
        }

        public IList<Folder> GetFolders()
        {
            return _folders;
        }

        public SingleWork GetWork(int id)
        {
            return _singleWorks.FirstOrDefault(i => i.Id == id);
        }

        public IList<SingleWork> GetWorks()
        {
            return _singleWorks;
        }

        public void UpdateFolder(Folder item)
        {
            var idx = -1;
            var matchedItem =
                (from x in _folders
                 let ind = idx++
                 where x.Id == item.Id
                 select ind).FirstOrDefault();

            if (idx == -1)
            {
                throw new Exception("Unable to update item. Item not found in collection.");
            }

            _folders[idx] = item;
        }

        public void UpdateWork(SingleWork item)
        {
            var idx = -1;
            var matchedItem =
                (from x in _singleWorks
                 let ind = idx++
                 where x.Id == item.Id
                 select ind).FirstOrDefault();

            if (idx == -1)
            {
                throw new Exception("Unable to update item. Item not found in collection.");
            }

            _singleWorks[idx] = item;
        }
    }
}
