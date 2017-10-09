using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoqApp
{
    public interface IDatabase
    {
        string[] GetValues();
        int GetCountOfVAlues();
    }
}
