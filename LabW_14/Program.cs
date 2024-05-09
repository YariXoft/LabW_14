using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LabW_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("Завдання 1: Робота з масивом цiлих чисел");

            int[] array = InputIntArray(); 
            array = FilterArray(array);
            SerializeAndSaveArray(array); 
            array = LoadAndDeserializeArray(); 

            // 2
            Console.WriteLine("\nЗавдання 2: Iнформацiя про музичний альбом");

            MusicAlbum album = CreateAlbum(); 
            SerializeAndSaveAlbum(album);
            album = LoadAndDeserializeAlbum(); 
            DisplayAlbumInfo(album); 

            // 3
            Console.WriteLine("\nЗавдання 3: Додавання списку пiсень до альбому");

            AddSongsToAlbum(album); 
            SerializeAndSaveAlbum(album); 
            DisplaySongs(album); 

            // 4
            Console.WriteLine("\nЗавдання 4: Масив альбомiв");

            List<MusicAlbum> albums = CreateAlbumsArray(); 
            SerializeAndSaveAlbumsArray(albums);
            albums = LoadAndDeserializeAlbumsArray(); 
            DisplayAlbumsArray(albums); 
        }

        static int[] InputIntArray()
        {
            Console.WriteLine("Введiть елементи масиву цiлих чисел, роздiленi пробiлами:");
            string input = Console.ReadLine();
            string[] strArray = input.Split(' ');
            int[] intArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                intArray[i] = int.Parse(strArray[i]);
            }
            return intArray;
        }

        static int[] FilterArray(int[] array)
        {
            return array;
        }

        static void SerializeAndSaveArray(int[] array)
        {
            string json = JsonConvert.SerializeObject(array);
            File.WriteAllText("array.txt", json);
        }

        static int[] LoadAndDeserializeArray()
        {
            string json = File.ReadAllText("array.txt");
            int[] array = JsonConvert.DeserializeObject<int[]>(json);
            return array;
        }

        class MusicAlbum
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public int Year { get; set; }
            public TimeSpan Duration { get; set; }
            public string RecordingStudio { get; set; }
            public List<Song> Songs { get; set; } // Пісні в альбомі
        }

        class Song
        {
            public string Title { get; set; }
            public TimeSpan Duration { get; set; }
            public string Genre { get; set; }
        }

        static MusicAlbum CreateAlbum()
        {
            MusicAlbum album = new MusicAlbum
            {
                Title = "Album Title",
                Artist = "Artist Name",
                Year = 2024,
                Duration = TimeSpan.FromMinutes(60),
                RecordingStudio = "Studio MusicProd",
                Songs = new List<Song>() // Cписок пісень
                {
                    new Song { Title = "Song 1", Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
                    new Song { Title = "Song 2", Duration = TimeSpan.FromMinutes(4), Genre = "Rock" }
                }
            };

            return album;
        }

        static void SerializeAndSaveAlbum(MusicAlbum album)
        {
            string json = JsonConvert.SerializeObject(album);
            File.WriteAllText("album.txt", json);
        }

        static MusicAlbum LoadAndDeserializeAlbum()
        {
            string json = File.ReadAllText("album.txt");
            MusicAlbum album = JsonConvert.DeserializeObject<MusicAlbum>(json);
            return album;
        }

        static void AddSongsToAlbum(MusicAlbum album)
        {
            album.Songs.Add(new Song { Title = "New Song 1", Duration = TimeSpan.FromMinutes(5), Genre = "Pop" });
            album.Songs.Add(new Song { Title = "New Song 2", Duration = TimeSpan.FromMinutes(4), Genre = "Rock" });
        }

        static void SerializeSongs(MusicAlbum album)
        {
            string json = JsonConvert.SerializeObject(album.Songs);
            File.WriteAllText("songs.txt", json);
        }

        static void DisplayAlbumInfo(MusicAlbum album)
        {
            Console.WriteLine($"Назва альбому: {album.Title}");
            Console.WriteLine($"Виконавець: {album.Artist}");
            Console.WriteLine($"Рiк випуску: {album.Year}");
            Console.WriteLine($"Тривалiсть: {album.Duration}");
            Console.WriteLine($"Студiя звукозапису: {album.RecordingStudio}");
        }

        static void DisplaySongs(MusicAlbum album)
        {
            Console.WriteLine("Список пiсень:");
            foreach (var song in album.Songs)
            {
                Console.WriteLine($"- {song.Title}, {song.Duration}, {song.Genre}");
            }
        }

        static List<MusicAlbum> CreateAlbumsArray()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum { Title = "Album 1", Artist = "Artist 1", Year = 2022 },
                new MusicAlbum { Title = "Album 2", Artist = "Artist 2", Year = 2023 }
            };

            return albums;
        }

        static void SerializeAndSaveAlbumsArray(List<MusicAlbum> albums)
        {
            string json = JsonConvert.SerializeObject(albums);
            File.WriteAllText("albums.txt", json);
        }

        static List<MusicAlbum> LoadAndDeserializeAlbumsArray()
        {
            string json = File.ReadAllText("albums.txt");
            List<MusicAlbum> albums = JsonConvert.DeserializeObject<List<MusicAlbum>>(json);
            return albums;
        }

        static void DisplayAlbumsArray(List<MusicAlbum> albums)
        {
            Console.WriteLine("Масив альбомiв:");
            foreach (var album in albums)
            {
                Console.WriteLine($"- {album.Title}, {album.Artist}, {album.Year}");
            }
        }
    }
}
