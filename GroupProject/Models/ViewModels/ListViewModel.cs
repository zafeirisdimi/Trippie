using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models.ViewModels
{
    public class ListViewModel<T>
    {
        public ICollection<T> Items { get; set; }

        public ListViewModel(ICollection<T> items)
        {
            Items = items;
        }
    }
}