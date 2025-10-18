using System.Media;
using System.Globalization;
using System.Threading;

public class AudioManager
{
    private SoundPlayer player = null;

    //--------------------------------------------------------------------------------------------

    public void PlayTicket(Ticket ticket)
    {
        SoundPlayer player = new SoundPlayer("Audio/gong.wav");
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

    public void PlayQueueSound(Ticket ticket)
    {
        // Play gong and other audio
        // new SoundPlayer("Audio/accept.wav").PlaySync();
        new SoundPlayer("Audio/welcome.wav").PlaySync();
        // new SoundPlayer($"Audio/{ticket.Number}.wav").PlaySync();
    }
}