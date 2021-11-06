using Newtonsoft.Json;
using System;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ConsoleApp
{
    class Program
    {
        public static TwilioSetting _twilioSetting;
        static void Main(string[] args)
        {
            try
            {
                LoadJson();
                string accountSid = _twilioSetting.TWILIO_ACCOUNT_SID;
                string authToken = _twilioSetting.TWILIO_AUTH_TOKEN;
                var random = new Random();
                int codeGenerate = random.Next(_twilioSetting.CODE_MIN, _twilioSetting.CODE_MAX);

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: $"Tu código de autenticación a { _twilioSetting.SYSTEM } es: { codeGenerate }",
                    from: new Twilio.Types.PhoneNumber(_twilioSetting.TWILIO_FROM),
                    to: new Twilio.Types.PhoneNumber(_twilioSetting.TWILIO_TO)
                );

                Console.WriteLine(message.Sid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void LoadJson()
        {
            using StreamReader streamReader = new StreamReader("appsetting.json");
            string json = streamReader.ReadToEnd();
            _twilioSetting = JsonConvert.DeserializeObject<TwilioSetting>(json);
        }
    }
}
