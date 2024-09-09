using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaExtraclase2
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue();
        int GetMidddle();

        void MergeSorted(IList listA, IList listB, ListSortDirection direction);
    }


    public enum SortDirection

    {
        Ascending, Descending
    }
}
