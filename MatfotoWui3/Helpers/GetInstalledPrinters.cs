using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Helpers
{
    class GetInstalledPrinters
    {
        private IList<string> _allPrinters;
        private IList<string> _filteredPrinters;
        private List<string> _citizenNames;
        

        public GetInstalledPrinters()
        {
            _citizenNames = new() { "CITIZEN CX-02", "CITIZEN CX-02W", "CY"};
        }

        public IList<string> AllPrinters
        {
            get => _allPrinters;
            set => GetAllPrinters();
        }

        public IList<string> FilteredPrinters
        {
            get => _filteredPrinters;
            set => GetFilteredCitizenPrinters();
        }

        private IList<string> GetAllPrinters() 
        {
            
            _allPrinters.Clear();
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                _allPrinters.Add(printname);
            }
            return _allPrinters;
            
        }

        private IList<string> GetFilteredCitizenPrinters()
        {
            _filteredPrinters.Clear();
            
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                foreach (var citizen in _citizenNames)
                {
                    var printNameToUpper = printname.ToUpper();

                    if (printNameToUpper.Equals(citizen))
                    {
                        _filteredPrinters.Add(printname);
                    }
                }
            }
            return _filteredPrinters;
        }
    }
}
