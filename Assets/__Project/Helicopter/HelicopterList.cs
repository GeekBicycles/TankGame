using System.Collections.Generic;

namespace Tank_Game
{
    public class HelicopterList : IHelicopterList
    {
        public List<IHelicopter> helicopters { get; }
        public IHelicopter current { get; set; }

        public HelicopterList()
        {
            helicopters = new List<IHelicopter>();
            current = null;
        }

        public void Remove(IHelicopter helicopter)
        {
            helicopters.Remove(helicopter);
            if (current == helicopter) current = null;
        }
    }
}
