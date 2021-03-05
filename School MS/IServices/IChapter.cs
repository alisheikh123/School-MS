using School_MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_MS.IServices
{
    interface IChapter
    {
        public IList<tblChapter> GetChapter();
    }
}
