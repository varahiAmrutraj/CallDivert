using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace adminlte.AdditionalClasses
{
    public class SendMessages
    {
        public static void SendMessage(string messageText)
        {
            var accountSid = "ACa2d415f883ff334fd86f0596fce02eba";
            var authToken = "bdfba385ac51aab75bdb5331df6ab6ae";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("whatsapp:+918275654510"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = messageText;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}