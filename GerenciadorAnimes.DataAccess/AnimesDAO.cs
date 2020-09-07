using Dapper;
using GerenciadorAnimes.DataAccess.Conexao;
using GerenciadorAnimes.Model;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAnimes.DataAccess
{
    public class AnimesDAO : Conexao.Conexao
    {
        public GerenciadorAnimes.Model.Animes CarregarAnime(int id)
        {

            try
            {
                SqlConnection conn = new SqlConnection(strConexao);
                conn.Open();

                return conn.Query<Animes>("SELECT * FROM Animes WHERE ID = @ID", new { ID = id }).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool InserirAnime(Model.Animes animes)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConexao);
                conn.Open();

                return conn.Query<Model.Animes>("INSERT INTO Animes(NOME, GENERO, VISUALIZADO, RECOMENDAVEL, NOTA) output INSERTED.ID VALUES (@Nome, @Genero, @Visualizado, @Recomendavel, @Nota)", 
                                    new 
                                    {
                                        Nome = animes.Nome,
                                        Genero = animes.Genero,
                                        Visualizado = animes.Visualizado,
                                        Recomendavel = animes.Recomendavel,
                                        Nota = animes.Nota
                                    }).Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AtualizarAnime(Model.Animes animes)
        {

            try
            {
                SqlConnection conn = new SqlConnection(strConexao);
                conn.Open();

                return conn.Execute("UPDATE Animes SET NOME = @Nome, GENERO = @Genero, VISUALIZADO = @Visualizado, RECOMENDAVEL = @Recomendavel, NOTA = @Nota WHERE ID = @ID",
                                    new
                                    {
                                        ID = animes.ID,
                                        Nome = animes.Nome,
                                        Genero = animes.Genero,
                                        Visualizado = animes.Visualizado,
                                        Recomendavel = animes.Recomendavel,
                                        Nota = animes.Nota
                                    }).Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletarAnime(int id)
        {

            try
            {
                SqlConnection conn = new SqlConnection(strConexao);
                conn.Open();

                return conn.Execute("DELETE Animes WHERE ID = @ID", new { ID = id}).Equals(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Model.Animes> ListarAnimes()
        {

            try
            {
                SqlConnection conn = new SqlConnection(strConexao);
                conn.Open();

                return conn.Query<Model.Animes>("SELECT * FROM Animes").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
