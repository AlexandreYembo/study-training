using System;

namespace EventAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video();
            var videoEncoder = new Publisher.VideoEncoder();
            var mailService = new Subscribers.MailServices();
            var messageService = new Subscribers.MessageService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }
}
