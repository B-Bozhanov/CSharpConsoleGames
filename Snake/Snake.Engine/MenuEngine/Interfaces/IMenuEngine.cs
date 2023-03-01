using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserDatabase.Interfaces;

namespace Snake.Engine.MenuEngine.Interfaces
{
        public interface IMenuEngine
        {
            IAccount Start();
        }
}
