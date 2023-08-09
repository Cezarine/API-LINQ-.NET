using ScreenSound.Models;

namespace ScreenSound.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
        {
            List<string?>todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();

            foreach (var genero in todosOsGenerosMusicais)
            {
                Console.WriteLine($"- {genero}");
            }
        }

        public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
        {
            List<string?> artistasPorGeneroMusica = musicas.Where(musica => musica.Genero!.Contains(genero))
                                                 .Select(musica => musica.Artista)
                                                 .Distinct()
                                                 .ToList();
            Console.WriteLine($"Exibindo os artistas por gênero musicas >>> {genero}");
            foreach (var artista in artistasPorGeneroMusica)
            {
                Console.WriteLine($"- {artista}");
            }
        }

        public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeArtista)
        {
            var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeArtista)).ToList();

            Console.WriteLine($"Exibindo os artistas por artista musicas >>> {nomeArtista}");
            foreach (var musica in musicasDoArtista)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }
    
        public static void FiltrarMusicaPorTonalidade(List<Musica> musicas, string tonalidade)
        {
            var musicasPorTonalidade = musicas
                .Where(musica => musica.tonalidade.Equals(tonalidade.ToUpper()))
                
                .ToList();

            Console.WriteLine($"Exibindo as musicas por tonalidade >>> {tonalidade}");
            foreach (var musica in musicasPorTonalidade)
            {
                Console.WriteLine($"- Cantor: {musica.Artista} \n  Música: {musica.Nome}\n");
            }
        }
    }
}
