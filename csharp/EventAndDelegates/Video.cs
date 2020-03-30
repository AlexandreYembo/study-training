using System;

namespace EventAndDelegates{
    public class Video {
        public string Title { get; set; }
    }

    public class VideoEventArgs: EventArgs{
        public Video Video { get; set; }
    }
}