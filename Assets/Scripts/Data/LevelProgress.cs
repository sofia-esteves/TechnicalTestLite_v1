using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    [System.Serializable]
    public class LevelProgress
    {
        public static LevelProgress Current;
        public  Dictionary<int, bool> LevelsInfo = new Dictionary<int, bool>();
    }
}
