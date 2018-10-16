using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.data
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
