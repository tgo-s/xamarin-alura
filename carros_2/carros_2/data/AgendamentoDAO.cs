using carros_2.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection Conn;
        public AgendamentoDAO(SQLiteConnection conn)
        {
            Conn = conn;
            this.Conn.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            try
            {
                Conn.Insert(agendamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
