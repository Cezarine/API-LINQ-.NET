using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScreenSound.Models
{
    internal class MusicasPreferidas
    {
        public string? Nome { get; set; }
        public List<Musica> ListaDeMusicasFavoritas { get; }
        public string JsonSerealizer { get; private set; }

        public MusicasPreferidas(string nome)
        { 
            this.Nome = nome;
            ListaDeMusicasFavoritas = new List<Musica>();
        }

        public void AdicionarMusicasFavoritas(Musica musica)
        {
            ListaDeMusicasFavoritas.Add(musica);
        }

        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine($"Essas são as músicas favoritas -> {this.Nome}");
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine($"-{musica.Nome} de {musica.Artista}");
            }
            Console.WriteLine();
        }

        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = this.Nome,
                musicas =this.ListaDeMusicasFavoritas
            });
            string nomeDoArquivo = $"musicas-favoritas-{this.Nome}.json";

            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"Json criado com sucesso!{Path.GetFullPath(nomeDoArquivo)}");
        }
    }
}
