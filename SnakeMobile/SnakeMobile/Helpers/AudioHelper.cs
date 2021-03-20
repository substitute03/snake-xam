using Android.Media;
using Plugin.SimpleAudioPlayer;
using System.Threading.Tasks;

namespace SnakeMobile.Helpers
{
    public class AudioHelper
    {
        // Don't this any of this will play async because the audio.Load and Play methods are not async.
        public static async Task PlayPelletEatenSoundAsync()
        {
            ISimpleAudioPlayer audio = CrossSimpleAudioPlayer.Current;
            audio.Load("PelletEaten.ogg");
            audio.Play();
        }

        public static void PlayGameOverSound()
        {
            ISimpleAudioPlayer audio = CrossSimpleAudioPlayer.Current;
            audio.Load("GameOver.ogg");
            audio.Play();
        }

        public static async Task PlayControlClickSoundAsync()
        {
            ISimpleAudioPlayer audio = CrossSimpleAudioPlayer.Current;
            audio.Load("ControlClick.ogg");
            audio.Play();
        }
    }
}
