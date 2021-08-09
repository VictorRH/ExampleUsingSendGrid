using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSenGrid.SendGrindLibrary.Model
{
    public class SendGridModel
    {
        public string SendGridAPIKey { get; set; }

        public string EmailFrom { get; set; }

        public string NameFrom { get; set; }

        public string Title { get; set; }

        public string PlainTextContent { get; set; }
    }
}
