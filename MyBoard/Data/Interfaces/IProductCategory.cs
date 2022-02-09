using MyBoard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
