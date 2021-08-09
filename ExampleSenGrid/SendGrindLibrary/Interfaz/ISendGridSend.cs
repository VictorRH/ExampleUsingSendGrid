using ExampleSenGrid.SendGrindLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSenGrid.SendGrindLibrary.Interfaz
{
    public interface ISendGridSend
    {
        Task<(bool result, string errorMessage)> SendEmail(SendGridModel data);

    }
}
