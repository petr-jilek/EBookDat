using EBookDat.Models.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat.Models.Collections
{
    public class EGCcollection : ObservableCollection<EGC>
    {
        public EGCcollection() { }
        public EGCcollection(bool defaultEGC) {
            if (defaultEGC) this.Add(new EGC("Nezařazeno"));
        }

        public void SortByName(bool up) {
            if (up) {
                for (int i = 0; i < this.Count - 1; i++) {
                    if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i + 1].Name, this[i].Name)) {
                        EGC buffer = this[i];
                        this[i] = this[i + 1];
                        this[i + 1] = buffer;
                        if (i > 0) {
                            i -= 2;
                        }
                    }
                }
            }
            else {
                for (int i = 0; i < this.Count - 1; i++) {
                    if (CzechAsciiSorter.CompareTwoStringsIsFirstUpToSecond(this[i].Name, this[i + 1].Name)) {
                        EGC buffer = this[i];
                        this[i] = this[i + 1];
                        this[i + 1] = buffer;
                        if (i > 0) {
                            i -= 2;
                        }
                    }
                }
            }
        }

    }
}
