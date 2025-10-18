using System.Media;
using System.Globalization;

class AudioPlayer
{
    public void PlayQueueSound(Ticket ticket)
    {
        // Play gong and other audio
        // new SoundPlayer("Audio/accept.wav").PlaySync();
        new SoundPlayer("Audio/welcome.wav").PlaySync();
        // new SoundPlayer($"Audio/{ticket.Number}.wav").PlaySync();
    }
}
