using System.Media;
using System.Globalization;
using System.Threading;

public class AudioManager
{
    private SoundPlayer player = new SoundPlayer();

    //--------------------------------------------------------------------------------------------

    public void PlayTicket(Ticket ticket) // TODO: fix freeze
    {
        player = new SoundPlayer("Audio/gong.wav");
        player.Load();
        player.PlaySync();

        string number = ticket.number.ToString("D3"); // make 3 digits callout

        foreach (char c in number)
        {
            string path = "Audio/" + c + ".wav";
            player = new SoundPlayer(path);
            player.PlaySync();
            // Thread.Sleep(300);
        }

    }
}