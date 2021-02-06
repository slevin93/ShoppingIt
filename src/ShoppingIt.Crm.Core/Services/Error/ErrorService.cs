using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Services.Error
{
    public class ErrorService : IErrorService
    {
        public void HandleBadRequest(string message)
        {
            throw new Exception(message);
        }
    }
}
