using System;


class SayaMusicTrack
{
   
    private int id;
    private int PlayCount;
    public string title;
    public SayaMusicTrack(string title)
    {
        this.title = title;
        this.PlayCount = 0;
        Random rnd = new Random();
        this.id = rnd.Next(10000, 100000);
    }
    public void IncreasePlayCount(int count)
    {
        this.PlayCount += count;
    }
    public void PrintTrackDetails()
    {
        Console.WriteLine($"Track {id} Judul: {title}");
       
    }
    public int getPlayCount()
    {
        return PlayCount;
    }
    
}

class SayaMusicUser
{
    private int id;
    public string Username;
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser(string username)
    {
        this.Username = username;
        this.uploadedTracks = new List<SayaMusicTrack>();   
        Random rnd = new Random();
        this.id = rnd.Next(10000, 100000);

    }
    public void Addtrack(SayaMusicTrack track)
    {
        uploadedTracks.Add(track);
    }
    public int GetTotalPlayCount()
    {
        int totalPlayCount = 0;
        foreach (SayaMusicTrack track in uploadedTracks)
        {
            totalPlayCount += track.getPlayCount();
        }
        return totalPlayCount;
    }
    public void PrintAllTracks()
    {
        Console.WriteLine($"User: {Username}'s Playlist:");
        foreach (var track in uploadedTracks)
        {
            track.PrintTrackDetails();
        }
    }
    public List<SayaMusicTrack> getuploadedTracks()
    {
        return uploadedTracks;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        SayaMusicUser user1 = new SayaMusicUser("Petrus Agustino");

        for (int i = 0; i < 10; i++)
        {
            SayaMusicTrack track = new SayaMusicTrack($"Song {i + 1}");
            Random rnd = new Random();
            int cnt = rnd.Next(1, 10);
            track.IncreasePlayCount(cnt);
            user1.Addtrack(track);
        }

        List<SayaMusicTrack> uploadedTracks = user1.getuploadedTracks();

        user1.PrintAllTracks();
        Console.WriteLine($"Total Play Count: {user1.GetTotalPlayCount()}");
        Console.WriteLine();
        foreach(SayaMusicTrack track in uploadedTracks)
        {
            Console.WriteLine($"Review Lagu {track.title} oleh {user1.Username}");
        }
        
    }
}