using System;
using System.Threading;

namespace EventAndDelegates.Publisher {
    public class VideoEncoder {
        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        // public event VideoEncodedEventHandler VideoEncoded;

        public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video){
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }
        
        protected virtual void OnVideoEncoded(Video video){
            if(VideoEncoded != null){
                VideoEncoded(this, new VideoEventArgs{Video = video});
            }
        }
    }
}