using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVienS.Common
{
    public class AppContextCustom
    {
        private static readonly AppContextCustom _instance = new AppContextCustom();
        public static AppContextCustom Instance => _instance;
        public AuthContext Auth { get; }
        private AppContextCustom()
        {
            Auth = new AuthContext();
        }
    }

}
