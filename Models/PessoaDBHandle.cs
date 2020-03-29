using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace rodrigo_alves_coelho_DR2_TP3rodrigo_alves_coelho_DR2_TP3.Models
{
    public class PessoaDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["pessoaconn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddPessoa(Pessoa smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewPessoa", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", smodel.Nome);
            cmd.Parameters.AddWithValue("@Aniversario", smodel.Aniversario);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Pessoa> GetPessoa()
        {
            connection();
            List<Pessoa> pessoalist = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand("GetPessoaDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                pessoalist.Add(
                    new Pessoa
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Nome = Convert.ToString(dr["Nome"]),
                        Aniversario = Convert.ToString(dr["Aniversario"]),
                    });
            }
            return pessoalist;
        }


        public bool UpdateDetails(Pessoa smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePessoaDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", smodel.Id);
            cmd.Parameters.AddWithValue("@Nome", smodel.Nome);
            cmd.Parameters.AddWithValue("@Aniversario", smodel.Aniversario);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeletePessoa(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePessoa", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}