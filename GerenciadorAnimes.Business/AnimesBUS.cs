using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAnimes.Business
{
    public class AnimesBUS
    {
        public Model.Animes CarregarAnime(int id)
        {
            try
            {
                return new DataAccess.AnimesDAO().CarregarAnime(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool InserirAnime(Model.Animes anime)
        {
            try
            {
                if (string.IsNullOrEmpty(anime.Nome))
                    throw new ArgumentException("Informe o nome do anime!");

                if (string.IsNullOrEmpty(anime.Genero))
                    throw new ArgumentException("Informe o genêro do anime!");

                if(anime.Nota > 10)
                    throw new ArgumentException("A nota informada precisa estar entre 1 e 10!");

                return new DataAccess.AnimesDAO().InserirAnime(anime);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool AtualizarAnime(Model.Animes anime)
        {
            try
            {
                if (string.IsNullOrEmpty(anime.Nome))
                    throw new ArgumentException("Informe o nome do anime!");

                if (string.IsNullOrEmpty(anime.Genero))
                    throw new ArgumentException("Informe o genêro do anime!");

                if (anime.Nota > 10)
                    throw new ArgumentException("A nota informada precisa estar entre 1 e 10!");

                return new DataAccess.AnimesDAO().AtualizarAnime(anime);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool DeletarAnime(int id)
        {
            try
            {
                return new DataAccess.AnimesDAO().DeletarAnime(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<Model.Animes> ListarAnimes()
        {
            try
            {
                return new DataAccess.AnimesDAO().ListarAnimes();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
