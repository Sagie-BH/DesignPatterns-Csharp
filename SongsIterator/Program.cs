using System;
using System.Collections.Generic;

namespace SongsIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SongInfo
    {
        string songName;
        string bandName;
        int yearReleased;

        public SongInfo(string newSongName, string newBandName, int newYearReleased)
        {
            songName = newSongName;
            bandName = newBandName;
            yearReleased = newYearReleased;
        }

        public string GetSongName() { return songName; }
        public string GetBandName() { return bandName; }
        public int GetYearReleased() { return yearReleased; }
    }
    public class SongOfThe70s
    {
        List<SongInfo> bestSongs;
        public SongOfThe70s()
        {
            bestSongs = new List<SongInfo>();

            AddSong("Imagine", "John Lennon", 1971);
            AddSong("I Will Survive", "Gloria Gaynor", 1979);
            AddSong("American Pie", "Don McLean", 1971);
        }
        public void AddSong(string songName, string bandName, int yearReleased)
        {
            SongInfo songInfo = new SongInfo(songName, bandName, yearReleased);
            bestSongs.Add(songInfo);


        }
        public List<SongInfo> GetBestSongs()
        {
            return bestSongs;
        }
        public Iterator CreateIterator()
        {

        }
    }