using System;

namespace EventAndDelegates.Subscribers {
    
    /*Subscriber 1*/
    public class MailServices {
        public void OnVideoEncoded(object source, VideoEventArgs args){
            Console.WriteLine("MailService: Sending an email..." + args.Video.Title);
        }
    }

    /*Subscriber 2*/
    public class MessageService {
        public void OnVideoEncoded(object source, VideoEventArgs args){
            Console.WriteLine("MessageService: Sending a text message" + args.Video.Title);
        }
    }
}