using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatfotoWui3.Helpers
{
    public class GetInstalledPrinters
    {
        private IList<string> _allPrinters;
        private IList<string> _filteredPrinters;
        private List<string> _citizenNames;
        

        public GetInstalledPrinters()
        {
            _citizenNames = new() { "CITIZEN CX-02", "CITIZEN CX-02W", "CY"};
            _allPrinters = GetAllPrinters();
            _filteredPrinters = GetFilteredCitizenPrinters();
        }

        public IList<string> AllPrinters
        {
            get => GetAllPrinters();            
        }

        public IList<string> FilteredPrinters
        {
            get => GetFilteredCitizenPrinters();            
        }

        private IList<string> GetAllPrinters() 
        {
            if (_allPrinters != null)
            {
                _allPrinters.Clear();
            }
            else
            {
                _allPrinters = new List<string>();
            }
            
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                _allPrinters.Add(printname);
            }
            return _allPrinters;
            
        }

        private IList<string> GetFilteredCitizenPrinters()
        {
            if (_filteredPrinters != null)
            {
                _filteredPrinters.Clear();
            }
            else
            {
                _filteredPrinters = new List<string>();
            }

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
