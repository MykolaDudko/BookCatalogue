using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;
public record Response<T>(int TotalItemsCount, IReadOnlyList<T> Items);
